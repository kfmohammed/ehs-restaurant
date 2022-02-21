using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;
using Restaurant.Repository.Masters;

namespace Restaurant.Model
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsRegistered { get; set; }

        public int AddUserProfile(UserProfile userProfile)
        {
            var userProfileItem = MapModeltoData(userProfile);
            return new Repository.Masters.UserProfileItem().AddUserProfile(userProfileItem);
        }

        public List<UserProfile> GetUserProfileList()
        {
            var returnList = new List<UserProfile>();
            var userProfileList = new Repository.Masters.UserProfileItem().GetUserProfile();

            if (userProfileList != null)
            {
                returnList.AddRange(userProfileList.Select(MapDatatoModel));
                return returnList;
            }

            return null;
        }

        public UserProfile GetUserProfile(int UserId)
        {
            return MapDatatoModel(new UserProfileItem().GetUserProfile(UserId));
        }

        
        #region Map POCO objects

        // Maps object from data to model
        private static UserProfile MapDatatoModel(DataModel.UserProfile exUserProfile)
        {
            if (exUserProfile != null)
            {
                return new UserProfile
                {
                    UserId = exUserProfile.UserId,
                    FirstName = exUserProfile.FirstName,
                    LastName = exUserProfile.LastName,
                    EmailAddress = exUserProfile.UserName,
                    AddressLine1 = exUserProfile.AddressLine1,
                    AddressLine2 = exUserProfile.AddressLine2,
                    AddressLine3 = exUserProfile.AddressLine3,
                    Postcode = exUserProfile.Postcode,
                    PhoneNumber = exUserProfile.PhoneNumber,
                    IsRegistered = exUserProfile.IsRegistered
                };
            }
            return null;
        }

        // Maps object from  to data repository
        private static Restaurant.DataModel.UserProfile MapModeltoData(UserProfile exUserProfile)
        {
            return new Restaurant.DataModel.UserProfile
            {
                UserId = exUserProfile.UserId,
                FirstName = exUserProfile.FirstName,
                LastName = exUserProfile.LastName,
                UserName = exUserProfile.EmailAddress,
                AddressLine1 = exUserProfile.AddressLine1,
                AddressLine2 = exUserProfile.AddressLine2,
                AddressLine3 = exUserProfile.AddressLine3,
                Postcode = exUserProfile.Postcode,
                PhoneNumber = exUserProfile.PhoneNumber,
                IsRegistered = exUserProfile.IsRegistered
            };
        }

        #endregion
    }
}
