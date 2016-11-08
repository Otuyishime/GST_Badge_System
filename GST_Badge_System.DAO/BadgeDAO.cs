using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace GST_Badge_System.DAO
{
    /*
     This class will be used to read/write all the badge data from the data database
     */
    public class BadgeDAO //: IcrudOperations<Badge>
    {
        public Badge create(Badge element)
        {
            throw new NotImplementedException();
        }

        public int delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Badge> list()
        {
            throw new NotImplementedException();
        }

        public Badge retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public Badge update(Badge element)
        {
            throw new NotImplementedException();
        }

        public List<Badge> ImportBadges(string filePath)
        {
            string line;
            List<Badge> badges = new List<Badge>();

            // Read the file and display it line by line.
            using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
            {
                file.ReadLine();    // Read to get rid of the first line
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    String[] splittedFields = line.Split(',');
                    Console.WriteLine(splittedFields.Length);
                    Badge temp_badge = new Badge();

                    if (!String.IsNullOrEmpty(splittedFields[0]) &&
                        !String.IsNullOrEmpty(splittedFields[1]) &&
                        !String.IsNullOrEmpty(splittedFields[2]))
                    {
                        //    temp_badge.Badge_Id = splittedFields[0];
                        //    temp_badge.Badge_Name = splittedFields[1];
                        //    temp_badge.Badge_Descript = splittedFields[2];

                        //    int year, month, day;
                        //    if (!String.IsNullOrEmpty(splittedFields[3]))
                        //    {
                        //        string[] activeDate = splittedFields[3].Split('/');

                        //        if (Int32.TryParse(activeDate[0], out month) &&
                        //        Int32.TryParse(activeDate[1], out day) &&
                        //        Int32.TryParse(activeDate[2], out year))
                        //        {
                        //            temp_badge.Badge_ActivateDate = new DateTime(year: year, month: month, day: day);
                        //        }
                        //    }

                        //    if (!String.IsNullOrEmpty(splittedFields[4]))
                        //    {
                        //        string[] retireDate = splittedFields[4].Split('/');

                        //        if (Int32.TryParse(retireDate[0], out month) &&
                        //        Int32.TryParse(retireDate[1], out day) &&
                        //        Int32.TryParse(retireDate[2], out year))
                        //        {
                        //            temp_badge.Badge_RetireDate = new DateTime(year: year, month: month, day: day);
                        //        }
                        //    }

                        //    temp_badge.Badge_Notes = String.IsNullOrEmpty(splittedFields[5]) ? "": splittedFields[5];
                        //    temp_badge.Badge_Image = splittedFields[6];
                    }
                    else
                    {
                        throw new Exception("One or more parameters failed to import!");
                    }

                    //badges.Add(temp_badge);
                }
            }

            return badges;
        }

        public int uploadBadges()
        {
            return 1;
        }
    }
}
