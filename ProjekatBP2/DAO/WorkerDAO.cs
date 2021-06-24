﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class WorkerDAO : BaseRepo<Worker>
    {
        public void MakesAppoitment(Worker worker, string nameOfClient, string surnameOfClient)
        {
            Appoitment appoitment = new Appoitment();
            appoitment.NameOfClient = nameOfClient;
            appoitment.SurnameOfClient = surnameOfClient;

            worker.Appoitments.Add(appoitment);

            Update(worker);
        }

        public void LocatedSector(Worker worker, string name)
        {
            Sector sector = new Sector();
            sector.SectorName = name;

            worker.Sectors.Add(sector);

            Update(worker);
        }

        public void SuperiorBoss(Worker worker, string name, string surname)
        {
            Boss boss = new Boss();
            boss.BossName = name;
            boss.BossSurname = surname;

            worker.Boss = boss;

            Update(worker);
        }

        public void ProvideBill(Worker worker, DateTime date)
        {
            Bill bill = new Bill();
            bill.Date = date;

            worker.Bill.Add(bill);

            Update(worker);
        }

        public void DoesJob(Worker worker) { }

        public bool CanDelete(int workerId)
        {
            using (var db = new BeautySalonContainer())
            {
                var worker = (from w in db.WorkerSet.Include("Boss.Workers").Include("Bill") where w.WorkerId == workerId select w).SingleOrDefault();

                if(worker.Boss != null)
                {
                    if(worker.Boss.Workers.Count == 1)
                    {
                        return false;
                    }
                }

                if(worker.Bill != null && worker.Bill.Count > 0)//ako postoje racuni onda se ne brise radnik
                {
                    return false;
                }

                return true;
            }
        }
    }
}