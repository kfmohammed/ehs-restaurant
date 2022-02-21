using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Repository.Masters
{
    public class UserProfileItem
    {
        public List<UserProfile> GetUserProfile()
        {
            using (var db = new ResturantDataContext())
            {
                var userProfiles = db.UserProfiles.ToList();
                return userProfiles.ToList();
            }
        }

        public UserProfile GetUserProfile(int UserId)
        {
            using (var db = new ResturantDataContext())
            {
                return db.UserProfiles.FirstOrDefault(p => p.UserId == UserId);
            }
        }

        public int AddUserProfile(DataModel.UserProfile userProfile)
        {
            using (var context = new ResturantDataContext())
            {
                context.UserProfiles.InsertOnSubmit(userProfile);
                context.SubmitChanges();
                return userProfile.UserId;
            }
            return 0;
        }

        public bool UpdateUserProfile(UserProfile userProfile, int UserId)
        {
            using (var context = new ResturantDataContext())
            {
                var userProfileItem = context.UserProfiles.SingleOrDefault(a => a.UserId == Convert.ToInt32(UserId));

                if (userProfileItem != null && userProfileItem.UserId != 0)
                {
                    userProfileItem.FirstName = userProfile.FirstName;
                    userProfileItem.LastName = userProfile.LastName;
                    userProfileItem.UserName = userProfile.UserName;
                    userProfileItem.AddressLine1 = userProfile.AddressLine1;
                    userProfileItem.AddressLine2 = userProfile.AddressLine2;
                    userProfileItem.AddressLine3 = userProfile.AddressLine3;
                    userProfileItem.Postcode = userProfile.Postcode;
                    userProfileItem.PhoneNumber = userProfile.PhoneNumber;
                    userProfileItem.IsRegistered = userProfile.IsRegistered;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}