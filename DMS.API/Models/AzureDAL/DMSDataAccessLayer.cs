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
        public User ReadFromDMS(User user)
        {
            var tempUser = from u in dmsContext.Users
                           where u.ID == user.ID
                           select u;
            
            return (User)tempUser;
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
                dmsContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
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
        public void UpdateToDMS(User user)
        {
            this.UpdateUserData(user);
        }

        /// <summary>
        /// Method To Delete User Data from DMS Table 
        /// </summary>
        /// <param name="User"></param>
        public void DeleteFromDMS(User user)
        {
            this.DeleteUserData(user);
            //dmsContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }

        /// <summary>
        /// Method To Read All Users from DMS Tables
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> ReadAllUsersFromDMS(int[] userIds = null)
        {
            IEnumerable<User> tempUser = null;
            
            try
            {
                //tempUser = from u in dmsContext.Users
                //           where userIds.Contains(u.ID)
                //           select u;
                tempUser = dmsContext.Users;

            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }

            return tempUser;
        }

        // TODO: Add Overloaded Method for WorkItem Table 

        /// <summary>
        /// Method to read Work item from DMS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WorkItem ReadFromDMS(WorkItem item)
        {
            var tempItem = from i in dmsContext.WorkItems
                           where i.ID == item.ID
                           select i;

            return (WorkItem)tempItem;
 
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
        public IEnumerable<WorkItem> ReadAllWorkItemsFromDMS(int[] itemList = null)
        {
            IEnumerable<WorkItem>tempItem = null;

            try
            {
                tempItem = from i in dmsContext.WorkItems
                           where itemList.Contains(i.ID)
                           select i;
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
            }

            return tempItem;

        }
        #endregion

        #region CRUD Methods

        private void UpdateUserData(User user)
        {
            try
            {
                if (user != null && user.ID > 0)
                {
                    User tempUser = dmsContext.Users.First(i => i.ID == user.ID);
                    dmsContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception e)
            {
                
                Logger.ErrorLog(e.Message); // TODO: Add custome Exceptions/ Logs
            }
        }

        private void DeleteUserData(User user)
        {
            try
            {
                if (user != null && user.ID > 0)
                {
                    User tempUser = dmsContext.Users.First(i => i.ID == user.ID);
                    dmsContext.DeleteObject(tempUser);
                    dmsContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message); // TODO: Add custome Exceptions/ Logs
            }
        }

        private void UpdateWorkItemData(WorkItem item)
        {
            try
            {
                if (item != null && item.ID > 0)
                {
                    WorkItem tempItem = dmsContext.WorkItems.First(i => i.ID == item.ID);
                    dmsContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception e)
            {

                Logger.ErrorLog(e.Message); // TODO: Add custome Exceptions/ Logs
            }
 
        }

        private void DeleteWorkItemData(WorkItem item)
        {
            try
            {
                if (item != null && item.ID > 0)
                {
                    WorkItem tempItem = dmsContext.WorkItems.First(i => i.ID == item.ID);
                    dmsContext.DeleteObject(tempItem);
                    dmsContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message); // TODO: Add custome Exceptions/ Logs
            }

        }

        #endregion 
    }
}