﻿using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public interface IEquipmentRepository: IRepository<Equipment>
    {
        ICollection<Equipment> GetEquipmentsByType(EquipmentType type);
    }
}
