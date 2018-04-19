﻿using Newtonsoft.Json;

namespace TeleTwitterLink.DTO
{
    public class TweeterUserDTO
    {
        [JsonProperty("id_str")]
        public string TweeterUserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("profile_image_url_https")]
        public string ImgUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
