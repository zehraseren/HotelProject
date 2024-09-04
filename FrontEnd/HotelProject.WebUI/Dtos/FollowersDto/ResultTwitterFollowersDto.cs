namespace HotelProject.WebUI.Dtos.FollowersDto
{
    public class ResultTwitterFollowersDto
    {
        public Result? result { get; set; }

        public class Result
        {
            public Data? data { get; set; }
        }

        public class Data
        {
            public User? user { get; set; }
        }

        public class User
        {
            public Result1? result { get; set; }
        }

        public class Result1
        {
            public Legacy? legacy { get; set; }
        }

        public class Legacy
        {
            public int followers_count { get; set; }
            public int friends_count { get; set; }
        }
    }
}
