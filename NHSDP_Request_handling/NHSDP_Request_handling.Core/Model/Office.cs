﻿using System.Collections.Generic;


namespace NHSDP_Request_handling.Core.Model
{
    public class Office : EntityBase
    {
        public string Adress { get; set; }
        public int CabinetsCount { get; set; }

        public ICollection<StudyingPlace> StudyingPlaces { get; set; }
    }
}
