﻿namespace Entities
{
    public class ManаgeCompany
    {
        public ManаgeCompany(string idName, string fslOwner, string officeAddress, int countHouse)
        {
            IdName = idName;
            FslOwner = fslOwner;
            OfficeAddress = officeAddress;
            CountHouse = countHouse;
        }

        public string IdName { get; set; }

        public string FslOwner { get; set; }

        public string OfficeAddress { get; set; }

        public int CountHouse { get; set; }
    }
}