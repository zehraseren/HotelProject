using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Dtos.FollowersDto;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Instagram
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/instagram"),
                Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto rifdto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.v1 = rifdto.followers;
                ViewBag.v2 = rifdto.following;
            }

            // Twitter
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter241.p.rapidapi.com/user?username=morkakullukiz"),
                Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "twitter241.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto rtfdto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.v3 = rtfdto.result.data.user.result.legacy.followers_count;
                ViewBag.v4 = rtfdto.result.data.user.result.legacy.friends_count;
            }

            // LinkedIn
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fzehraseren%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false&include_company_public_url=false"),
                Headers =
    {
        { "x-rapidapi-key", "85e0067b92mshaad1b9d110ca2c4p1ffe7fjsn7fea82739ad4" },
        { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedInFollowersDto rlfdto = JsonConvert.DeserializeObject<ResultLinkedInFollowersDto>(body3);
                ViewBag.v5 = rlfdto.data.follower_count;
                ViewBag.v6 = rlfdto.data.connection_count;
            }
            return View();
        }
    }
}
