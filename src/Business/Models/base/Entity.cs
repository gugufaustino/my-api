using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {

        }

        public int Id { get; set; }
    }
}
