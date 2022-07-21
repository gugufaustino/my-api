﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUser
    {
        string Id { get; }
        string UserName { get; }
        string Email { get; }
    }
}
