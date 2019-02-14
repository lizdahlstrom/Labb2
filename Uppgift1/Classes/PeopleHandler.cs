﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Caliburn.Micro;
using Uppgift1.Models;

namespace Uppgift1.Classes
{
    public static class PeopleHandler
    {
        private const string FileName = "people.bin";

        public static List<PersonModel> LoadPeople()
        {
            return File.Exists(FileName) ? (List<PersonModel>)FileOperations.Deserialize(FileName) : new List<PersonModel>();
        }

        public static void SaveToFile(List<PersonModel> people)
        {
            FileOperations.Serialize(people, FileName);
        }
    }
}
