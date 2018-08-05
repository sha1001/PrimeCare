using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataStructure;
using DataStructure.Entity;
using PrimeCare.Repository;

namespace PrimeCare.Business
{
    public class ResourceManager
    {
        const int TotalBedCount = 8;
        public ResourceScreen GetResourceData()
        {
            
            // get the Resource list entity from the database. 
            ResourceRepository resourceRepository = new ResourceRepository();
            List<ResourceEntity> list = resourceRepository.LoadList(null);

            if (list == null)
                return null;

            ResourceScreen resourceScreen = new ResourceScreen();
            resourceScreen.BedOccupied = GetOccupiedBedCount(list);
            resourceScreen.BedEmpty = TotalBedCount - resourceScreen.BedOccupied;
            resourceScreen.CurrentOccupancy = GetOccupancyRate(resourceScreen);

            return resourceScreen;
        }

        private string GetOccupancyRate(ResourceScreen resourceScreen)
        {
            return $"{((resourceScreen.BedOccupied / TotalBedCount) * 100).ToString()}%";
        }

        private int GetOccupiedBedCount(List<ResourceEntity> list)
        {
            int occupiedCount = 0;
            foreach(ResourceEntity res in list)
            {
                if(((res.CurrentTime -res.PacuAdmitTime).TotalMinutes > 0.0) && ((res.PacuDischargeTime - res.CurrentTime).TotalMinutes > 0.0))
                {
                    occupiedCount++;
                }
                
            }
            return occupiedCount;
        }
    }
}