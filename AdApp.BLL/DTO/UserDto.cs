﻿using System.Collections.Generic;

namespace AdApp.BLL.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public string Name { get; set; }

    }
}
