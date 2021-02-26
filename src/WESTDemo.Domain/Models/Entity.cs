using System;
using System.Collections.Generic;
using System.Text;

namespace WESTDemo.Domain.Models
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }
}
