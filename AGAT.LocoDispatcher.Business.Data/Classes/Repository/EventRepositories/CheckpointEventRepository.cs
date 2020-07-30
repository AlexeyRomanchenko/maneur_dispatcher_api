﻿using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories
{
    public class CheckpointEventRepository
    {
        public async Task CreatAsync(CheckpointEvent _event)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                _event.CreatedAt = DateTime.Now;
                context.CheckpointEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }
    }
}
