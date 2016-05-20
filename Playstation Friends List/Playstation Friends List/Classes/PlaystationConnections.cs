using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Playstation_Friends_List
{
    public class PlaystationConnections
    {
        #region 
        private string client_id = "b7aad20f-95c4-4079-8d96-e5b51009edb7";
        public string Client_Id { get; }
        private string client_secret = "366VVlqaKYrGlw7O";
        public string Client_Secret { get; }
        private string grant_code;
        public string Grant_Code { get; set; }
        private string auth_token;
        public string Auth_Token { get; set; }
        private string profile_cookie;
        public string Profile_Cookie { get; set; }
        private string user_id;
        public string User_Id { get; set; }
        #endregion
        public delegate void FriendList(string userID, string avatarUrl, string onlineStatus,
                          string platForm, string gameTitle, string gameStatus);
        public event FriendList FriendListHandler;
        HttpClient client;
        public string PlaystationCookie(string Username, string Password)
        {
            client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://auth.api.sonyentertainmentnetwork.com/2.0/ssocookie");
            var postData = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "authentication_type","password" },
                { "username" , Username },
                {"password", Password },
                {"client_id",client_id }
            });
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "com.playstation.mobilemessenger");
            client.DefaultRequestHeaders.ExpectContinue = false;
            request.Content = postData;
            Task<HttpResponseMessage> response = client.SendAsync(request);
            var input = response.Result.Content.ReadAsStringAsync();
            var parse = Newtonsoft.Json.JsonConvert.DeserializeObject<AccountProfile>(input.Result);
            profile_cookie = parse.npsso;
            if (!string.IsNullOrWhiteSpace(profile_cookie))
                PlaystationCode();
            return input.Result;
        }
        public string PlaystationCode()
        {
            HttpRequestMessage requst = new HttpRequestMessage(HttpMethod.Get, "https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/authorize?state=341434570&duid=00000007000201289024e96fada3a0b83a507265737469676520203a456c697465375153202000000000000000&ui=pr&client_id=b7aad20f-95c4-4079-8d96-e5b51009edb7&device_base_font_size=8.5&device_profile=tablet&redirect_uri=com.playstation.mobilemessenger.scecompcall%3A%2F%2Fredirect&response_type=code&scope=psn%3Asceapp%2Cuser%3Aaccount.get%2Cuser%3Aaccount.settings.privacy.get%2Cuser%3Aaccount.settings.privacy.update%2Cuser%3Aaccount.realName.get%2Cuser%3Aaccount.realName.update%2Ckamaji%3Aget_account_hash%2Ckamaji%3Augc%3Adistributor%2Coauth%3Amanage_device_usercodes%2Ccapone%3Areport_submission&service_entity=urn%3Aservice-entity%3Apsn&service_logo=ps&smcid=psmsgr%3Asignin&support_scheme=sneiprls");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "com.playstation.mobilemessenger");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.Add("Connection", new string[] { "Keep-Alive" });
            client.DefaultRequestHeaders.ExpectContinue = false;
            Task<HttpResponseMessage> response = client.SendAsync(requst);
            string responseheader = response.Result.Headers.GetValues("Location").FirstOrDefault();
            string str = "com.playstation.mobilemessenger.scecompcall://redirect/?code=";
            int start = responseheader.IndexOf(str, StringComparison.Ordinal) + str.Length;
            int end = responseheader.IndexOf("&state", start, StringComparison.Ordinal) - start;
            grant_code = responseheader.Substring(start, end);
            if (!string.IsNullOrWhiteSpace(grant_code))
                PlaystationToken();
                return grant_code;
        }

        public string PlaystationToken()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/token");
            var postData = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type","authorization_code" }   ,
                {"client_id", client_id  },
                {"client_secret", client_secret },
                {"redirect_uri","com.playstation.mobilemessenger.scecompcall://redirect" } ,
                {"scope","psn:sceapp,user:account.get,user:account.settings.privacy.get,user:account.settings.privacy.update,user:account.realName.get,user:account.realName.update,kamaji:get_account_hash,kamaji:ugc:distributor,oauth:manage_device_usercodes,capone:report_submission" },
                {"code", grant_code },
                {"service_entity","urn:service-entity:psn" },
                {"duid", "00000007000201289024e96fada3a0b83a507265737469676520203a456c697465375153202000000000000000" }
            });
            client.DefaultRequestHeaders.Add("User-Agent", "com.sony.snei.np.android.sso.share.oauth.versa.USER_AGENT");
            client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", client_id, client_secret))));
            client.DefaultRequestHeaders.Add("X-Requested-With", "com.playstation.mobilemessenger");
            client.DefaultRequestHeaders.Add("Connection", new string[] { "Keep-Alive" });
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.ExpectContinue = false;
            request.Content = postData;
            Task<HttpResponseMessage> response = client.SendAsync(request);
            var input = response.Result.Content.ReadAsStringAsync();
            var parse = Newtonsoft.Json.JsonConvert.DeserializeObject<AccountProfile>(input.Result);
            auth_token = parse.access_token;
            if (!string.IsNullOrWhiteSpace(auth_token))
                PlaystationAuth();
            return input.Result;
        }

        public string PlaystationAuth()
        {
            HttpRequestMessage requst = new HttpRequestMessage(HttpMethod.Get, "https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/token/" + auth_token);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "com.playstation.mobilemessenger");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.Add("Connection", new string[] { "Keep-Alive" });
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", client_id, client_secret))));
            Task<HttpResponseMessage> response = client.SendAsync(requst);
            var input = response.Result.Content.ReadAsStringAsync();
            var parse = Newtonsoft.Json.JsonConvert.DeserializeObject<AccountProfile>(input.Result);
            user_id = parse.online_id;
            if (!string.IsNullOrWhiteSpace(user_id))
                PlaystationAvatar();
            Program.MainWindow.accountName(user_id);
            Program.MainWindow.Text = "Playstation Messanger (" + user_id + ")";
            return input.Result;
        }

        public string PlaystationAvatar()
        {
            HttpRequestMessage requst = new HttpRequestMessage(HttpMethod.Get, "https://us-prof.np.community.playstation.net/userProfile/v1/users/me/profile2?fields=npId%2CprimaryOnlineStatus%2Cpresences%28%40titleInfo%29%2CisOfficiallyVerified%2CpersonalDetail%28%40default%2CprofilePictureUrls%29%2CpersonalDetailSharing%2CavatarUrls%2CfriendRelation&avatarSizes=s&profilePictureSizes=m");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "com.playstation.mobilemessenger");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.Add("Connection", new string[] { "Keep-Alive" });
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth_token);
            Task<HttpResponseMessage> response = client.SendAsync(requst);
            var input = response.Result.Content.ReadAsStringAsync();
            JObject avatarResult = JObject.Parse(input.Result);
            IList<JToken> avatarResults = avatarResult["profile"].Parent.ToList();
            foreach(var avatar in avatarResults)
            {
              AccountProfile  profile = JsonConvert.DeserializeObject<AccountProfile>(avatar.ToString());
                Program.MainWindow.avatarPic(profile.avatarUrls[0].avatarUrl);
            }
            if (!string.IsNullOrWhiteSpace(input.Result))
                Program.MainWindow.SignInWindow.Hide();
            PlaystationFriendList();
            return input.Result;
        }

        public string PlaystationFriendList()
        {
            try
            {
                HttpRequestMessage requst = new HttpRequestMessage(HttpMethod.Get, "https://us-prof.np.community.playstation.net/userProfile/v1/users/me/friends/profiles2?fields=onlineId%2CavatarUrls%2Cplus%2CtrophySummary(%40default)%2CisOfficiallyVerified%2CpersonalDetail(%40default%2CprofilePictureUrls)%2CprimaryOnlineStatus%2Cpresences(%40titleInfo%2ChasBroadcastData)&sort=name-onlineId&userFilter=online&avatarSizes=s&profilePictureSizes=m&offset=0&limit=36");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-Requested-With", "com.playstation.mobilemessenger");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
                client.DefaultRequestHeaders.Add("Connection", new string[] { "Keep-Alive" });
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth_token);
                Task<HttpResponseMessage> response = client.SendAsync(requst);
                var input = response.Result.Content.ReadAsStringAsync();
                dynamic friendresult = JsonConvert.DeserializeObject(input.Result);
                foreach (var result in friendresult.profiles)
                {
                    Profiles profileinfo = JsonConvert.DeserializeObject<Profiles>(result.ToString());
                    Program.MainWindow.FriendList(profileinfo.onlineId, profileinfo.avatarUrls[0].avatarUrl, profileinfo.presences[0].onlineStatus, profileinfo.presences[0].platform, profileinfo.presences[0].titleName, profileinfo.presences[0].gameStatus);
                }
                if (!string.IsNullOrWhiteSpace(input.Result))
                    Program.MainWindow.addMarquee("Status: Sign In as " + user_id);
                return input.Result;
            }
            catch { return "error"; }
        } 
    }

 
}
