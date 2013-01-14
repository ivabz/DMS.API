using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using DMS.API.Models;
using DMS.API.Utilities;


namespace DMS.API.Models.AzureDAL
{
    public class DMSDataAccessLayer
    {
        private DefectManagementSystemEntities dmsContext = new DefectManagementSystemEntities();

        #region DAL Methods 
        /// <summary>
        /// Method to Read User Data From DMS Table 
        /// </summary>
        /// <param name="User"></param>
        public UserDTO ReadFromDMS(User user)
        {
            UserDTO tempUser = null;

            try
            {
                tempUser = MapUsersDTO().First(u => u.ID == user.ID);
            }

            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }

            return tempUser;
        }

        /// <summary>
        /// Method To Insert User Data In to DMS Table 
        /// </summary>
        /// <param name="User"></param>
        public void InsertToDMS(User user)
        {
            try
            {
                dmsContext.AddToUsers(user);
                dmsContext.SaveChanges(System.Data.Objects.SaveOptions.None);
            }

            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }
        }

        /// <summary>
        /// Method to Update user Data in DMS Table 
        /// </summary>
        /// <param name="User"></param>
        public bool UpdateToDMS(User user)
        {
            return (this.UpdateUserData(user) ? true : false);
            
        }

        /// <summary>
        /// Method To Delete User Data from DMS Table 
        /// </summary>
        /// <param name="User"></param>
        public bool  DeleteFromDMS(User user)
        {
            return (this.DeleteUserData(user) ? true : false);
        }

        /// <summary>
        /// Method To Read All Users from DMS Tables
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> ReadAllUsersFromDMS(int[] userIds = null)
        {
            try
            {
                return MapUsersDTO().AsEnumerable();
            }

            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
                throw e;
            }

            
        }

        /// <summary>
        /// Method to read Work item from DMS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WorkItemDTO ReadFromDMS(WorkItem item)
        {
            WorkItemDTO tempItem = null;
           try
            {
                tempItem = MapWorkItemsDTO().First(u => u.ID == item.ID);
            }

            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
                throw e;
            }

            return tempItem;
 
        }

        /// <summary>
        /// Method to Insert Workitems data to DMS
        /// </summary>
        /// <param name="item"></param>
        public void InsertToDMS(WorkItem item)
        {
            try
            {
                dmsContext.AddToWorkItems(item);
                dmsContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }

        }

        /// <summary>
        /// Method to update Workitems to DMS 
        /// </summary>
        /// <param name="item"></param>
        public void UpdateToDMS(WorkItem item)
        {
            this.UpdateWorkItemData(item);

        }

        /// <summary>
        /// Method to delete Workitems from DMS
        /// </summary>
        /// <param name="item"></param>
        public void DeleteFromDMS(WorkItem item)
        {
            this.DeleteWorkItemData(item);
        }

        /// <summary>
        /// Method to read all workitems from DMS
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WorkItemDTO> ReadAllWorkItemsFromDMS(int[] itemList = null)
        {
            IEnumerable<WorkItemDTO> tempItem = null;

            try
            {
                tempItem = MapWorkItemsDTO().AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }

            return tempItem;

        }
        #endregion

        private IQueryable<UserDTO> MapUsersDTO()
        {
            return from u in dmsContext.Users
                   select new UserDTO() { ID = u.ID, First_Name = u.First_Name, Last_Name = u.Last_Name, Login_Id = u.Login_Id, Password = u.Password, Role = u.Role };
        }


        private IQueryable<WorkItemDTO> MapWorkItemsDTO()
        {
            return from u in dmsContext.WorkItems
                   select new WorkItemDTO()
                   {
                       ID = u.ID,
                       type = u.Type,
                       Status = u.Status,
                       Title = u.Title,
                       Description = u.Description,
                       Priority = u.Priority,
                       Severity = u.Severity,
                       Environment = u.Environment,
                       OS = u.OS,
                       Browser = u.Browser,
                       Resolution = u.Resolution,
                       Build = u.Build,
                       AssignTo = u.AssignTo,
                       OpenedBy = u.OpenedBy,
                       ActivatedBy = u.ActivatedBy,
                       ClosedBy = u.ClosedBy,
                       AreaPath = u.AreaPath
                   };
        }


        #region CRUD Methods

        private bool UpdateUserData(User user)
        {
            bool isUpdated = false;
            try
            {

                if (user != null && user.ID > 0)
                {
                    User tempUser = dmsContext.Users.First(i => i.ID == user.ID);

                    if (tempUser != null)
                    {
                        // TODO : Write Custom SP's for each DB operation and call corresponding methods here
                        // Doing it programatically is ****
                        tempUser.First_Name = user.First_Name;
                        tempUser.Last_Name = user.Last_Name;
                        tempUser.Login_Id = user.Login_Id;
                        tempUser.Password = user.Password;
                        tempUser.Role = tempUser.Role;
                        
                        dmsContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }

            return isUpdated;
        }
                    
        private bool DeleteUserData(User user)
        {
            bool isDeleted = false;
            try
            {
                if (user != null && user.ID > 0)
                {
                    User tempUser = dmsContext.Users.First(i => i.ID == user.ID);
                    if (tempUser != null)
                    {
                        dmsContext.DeleteObject(tempUser);
                        dmsContext.SaveChanges();
                        isDeleted= true;
                    }
                    else
                    {
                        isDeleted = false;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message); // TODO: Add custom Exceptions/ Logs
            }

            return isDeleted;
        }

        private bool UpdateWorkItemData(WorkItem item)
        {
            bool isUpdated = false;
            try
            {
                if (item != null && item.ID > 0)
                {
                    WorkItem tempItem = dmsContext.WorkItems.First(i => i.ID == item.ID);
                    if (tempItem != null)
                    {

                        // TODO : Write Custom SP's for each DB operation and call corresponding methods here
                        dmsContext.SaveChanges();
                        isUpdated =  true;
                    }
                    else
                    {
                        isUpdated = false;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {

                Logger.ErrorLog(e.Message); // TODO: Add custom Exceptions/ Logs
            }
            
            return isUpdated;
        }

        private bool DeleteWorkItemData(WorkItem item)
        {
            bool isDeleted = false;
            try
            {
                if (item != null && item.ID > 0)
                {
                    WorkItem tempItem = dmsContext.WorkItems.First(i => i.ID == item.ID);
                    if (tempItem != null)
                    {
                        dmsContext.DeleteObject(tempItem);
                        dmsContext.SaveChanges();
                        isDeleted = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message); // TODO: Add custom Exceptions/ Logs
            }

            return isDeleted;
        }

        #endregion 
    }
}