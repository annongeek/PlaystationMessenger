using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playstation_Friends_List
{
    #region Your Profile
    public class AccountProfile
    {
        public string npsso { get; set; }
        public string access_token { get; set; }
        public string online_id { get; set; }
        public List<AccountAvatarUrl> avatarUrls { get; set; }
    }

    public class AccountAvatarUrl
    {
        public string size { get; set; }
        public string avatarUrl { get; set; }
    }
    #endregion

    #region Friendslist
    public class AvatarUrl
    {
        public string size { get; set; }
        public string avatarUrl { get; set; }
    }
    public class Presence
    {
        public string onlineStatus { get; set; }
        public string platform { get; set; }
        public string npTitleId { get; set; }
        public string titleName { get; set; }
        public string npTitleIconUrl { get; set; }
        public string gameStatus { get; set; }
        public bool hasBroadcastData { get; set; }
    }

    public class PersonalDetail
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class Profiles
    {
        public string onlineId { get; set; }
        public List<AvatarUrl> avatarUrls { get; set; }
        public bool isOfficiallyVerified { get; set; }
        public string personalDetailSharing { get; set; }
        public PersonalDetail personalDetail { get; set; }
        public string primaryOnlineStatus { get; set; }
        public List<Presence> presences { get; set; }
        public string friendRelation { get; set; }
        public bool following { get; set; }
        public TrophySummary trophySummary { get; set; }
    }

    public class TrophySummary
    {
        public int level { get; set; }
    }

    public class ProfileLookup
    {
        public string onlineId { get; set; }
        public List<AvatarUrl> avatarUrls { get; set; }
        public int plus { get; set; }
        public TrophySummary trophySummary { get; set; }
        public bool isOfficiallyVerified { get; set; }
    }

    #endregion
}
