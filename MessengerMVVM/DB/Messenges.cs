﻿using System;
using System.ComponentModel.DataAnnotations;


namespace MessengerMVVM.DB
{
    public class Message
    {
        [Key] 
        public int id;
        public int senderid;
        public int receiverid;
        [Required]
        public string content;
        public DateTime timestamp;
    }
}
