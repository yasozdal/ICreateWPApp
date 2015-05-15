﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class User
    {
        public string UserName { get; set; }
        public int UserId { get; set; }

        public string Photo { get; set; }
        //List<User> Friends { get; set; }
        //string un;
        //int ui;
        //string p;

        public User(string userName, int userId, string photo)
        {
            UserName = userName;
            UserId = userId;
            Photo = photo;
        }
    }
}
