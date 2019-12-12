using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;

namespace CIT255_KT_list_builder.Data
{
    class SeedData
    {
        #region PROPERTIES
        // Temp: 
        private static List<FighterMeleeWeapons> AvailableMeleeWeapons { get; set; }
        private static List<FighterRangedWeapons> AvailableRangedWeapons { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SeedData()
        {
            AvailableMeleeWeapons = GenerateListOfMeleeWeapons();
            AvailableRangedWeapons = GenerateListOfRangedWeapons();

        }
        #endregion

        #region DATA GENERATION METHODS

        /// <summary>
        /// Creates a FighterList object to conduct test operations on;
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<FighterList> GenerateRoster()
        {
            List<FighterList> seedList = new List<FighterList>()
            {
                new FighterList()
                {
                    ListName = "Sample List",
                    ListID = 0,
                    NumberOfSpecialists = 0,
                    MaxPoints = 100,
                    SelectedFighters = new List<Fighter>()
                    {

                    new Fighter()
                    {
                        FighterName = "Shifty",
                        FighterID = 0,
                        FighterCost = 8,
                        FighterType = "Acolyte Leader",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "AcolyteLeader.PNG",
                        IsSpecialist = true,
                        FighterSpecialization =  Fighter.Specializations.LEADER,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                           new FighterMeleeWeapons(2000, 0, "Cult Knife", "Type: Melee, S: User,  AP -, Damage: 1, A model may make 1 free attack with this weapon when they fight."),
                           new FighterMeleeWeapons(2001, 0, "Rending Claw", "Type: Melee S: User,  AP -1, Damage: 1, To-wound rolls of 6+ are resolved at AP-4."),
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterID = 1,
                        FighterName = "Scrapper",
                        FighterCost = 8,
                        FighterType = "Acolyte Fighter",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "AcolyteFighter.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                            new FighterMeleeWeapons(2006, 3, "Heavy Rock Saw", "Type: MeleeS:2X,  AP -4, Damage: 2"),
                        },
                        FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                        {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterName = "Slick",
                        FighterID = 2,
                        FighterCost = 7,
                        FighterType = "Acolyte Hybrid",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "AcolyteHybrid.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {
                            new FighterWargear(1000, 10, "Icon", "Nearby fighters can reroll hit rolls of 1 in melee."),

                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                           new FighterMeleeWeapons(2000, 0, "Cult Knife", "Type: Melee, S: User,  AP -, Damage: 1, A model may make 1 free attack with this weapon when they fight."),
                           new FighterMeleeWeapons(2001, 0, "Rending Claw", "Type: Melee S: User,  AP -1, Damage: 1, To-wound rolls of 6+ are resolved at AP-4."),
                        },
                        FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                        {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterID = 3,
                        FighterName = "Slicer",
                        FighterCost = 8,
                        FighterType = "Metamorph",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "MetamorphHybrid.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                           new FighterMeleeWeapons(2010, 0, "Metamorph Talon", "Type: Melee, S: user, AP -, Damage: 1, +1 Attack, add +2 to hit rolls when attacking with this weapon."),
                           new FighterMeleeWeapons(2010, 0, "Metamorph Talon", "Type: Melee, S: user, AP -, Damage: 1, +1 Attack, add +2 to hit rolls when attacking with this weapon."),
                        },
                        FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                        {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT
                        }
                    },
                    new Fighter()
                    {
                        FighterID = 4,
                        FighterName = "Crusher",
                        FighterCost = 8,
                        FighterType = "Metamorph",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "Metamorph.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                          new FighterMeleeWeapons(2009, 2, "Metamorph Claw", "Type: Melee, S: +2, AP - 1, Damage: 1"),
                        },
                        FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                        {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                }
                },
                new FighterList()
            {
                ListName = "Mining Corps",
                ListID = 1,
                NumberOfSpecialists = 0,
                MaxPoints = 100,
                SelectedFighters = new List<Fighter>()
                {

                    new Fighter()
                    {
                        FighterID = 6,
                        FighterName = "Isaak",
                        FighterCost = 6,
                        FighterType = "Neophyte Leader",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "NeophyteLeader.PNG",
                        IsSpecialist = true,
                        FighterSpecialization =  Fighter.Specializations.LEADER,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                           new FighterMeleeWeapons(2000, 0, "Cult Knife", "Type: Melee, S: User,  AP -, Damage: 1, A model may make 1 free attack with this weapon when they fight."),

                        },
                        FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                        {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterID = 7,
                        FighterName = "Ganner",
                        FighterCost = 5,
                        FighterType = "Neophyte Hybrid",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "NeophyteHybrid.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                        FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {

                        },
                         FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                         {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                              new FighterRangedWeapons(3003, 0, "Autogun", "Type: Rapid Fire, S:3,  AP -, Damage 1, This weapon fires an additional shot at half range.")

                         },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT
                        },

                    },
                    new Fighter()
                    {
                        FighterID = 8,
                        FighterName = "Michon",
                        FighterCost = 5,
                        FighterType = "Neophyte Hybrid",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "NeophyteHybrid.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                        FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {

                        },
                         FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                         {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                              new FighterRangedWeapons(3003, 0, "Autogun", "Type: Rapid Fire, S:3,  AP -, Damage 1, This weapon fires an additional shot at half range.")

                         },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterID = 9,
                        FighterName = "Groust",
                        FighterCost = 5,
                        FighterType = "Neophyte Gunner",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "NeophyteGunner.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {

                        },
                         FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                         {
                              new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                              new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                              new FighterRangedWeapons(3006, 0, "Mining Laser", "Type: Heavy 1, S:9,  AP -3, Damage: D3, Subtract 1 from hit rolls made with this weapon if the bearer moves"),

                         },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterID = 10,
                        FighterName = "Gruk",
                        FighterCost = 16,
                        FighterType = "Aberrant",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "Aberrant1.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                         FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                          new FighterMeleeWeapons(2008, 5, "Power Pick", "Type: Melee, S: user, AP - 2, Damage: D3"),
                          new FighterMeleeWeapons(2001, 0, "Rending Claw", "Type: Melee S: User,  AP -1, Damage: 1, To-wound rolls of 6+ are resolved at AP-4.")
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                    new Fighter()
                    {
                        FighterID = 11,
                        FighterName = "Crasker",
                        FighterCost = 16,
                        FighterType = "Aberrant",
                        FighterFaction = "Genestealer Cults",
                        ImgFile = "Aberrant2.PNG",
                        IsSpecialist = false,
                        FighterSpecialization =  Fighter.Specializations.NONE,
                        FighterEquipmentList = new List<FighterWargear>
                        {


                        },
                        FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                        {
                          new FighterMeleeWeapons(2008, 5, "Power Pick", "Type: Melee, S: user, AP - 2, Damage: D3"),
                          new FighterMeleeWeapons(2001, 0, "Rending Claw", "Type: Melee S: User,  AP -1, Damage: 1, To-wound rolls of 6+ are resolved at AP-4.")
                        },
                        FighterSpecializationOptions = new List<Fighter.Specializations>
                        {
                         Fighter.Specializations.NONE,
                         Fighter.Specializations.LEADER,
                         Fighter.Specializations.COMBAT,
                         Fighter.Specializations.COMMS,
                         Fighter.Specializations.ZEALOT

                        }
                    },
                }
            },
            };


            return seedList;
        }

        /// <summary>
        /// Generates a list of available fighters:
        /// </summary>
        /// <returns></returns>
        public static List<Fighter> GenerateListOfAvailableFighters()
        {

            List<Fighter> fighters = new List<Fighter>()
            {

                new Fighter()
                {
                     FighterType = "Acolyte Leader",
                     FighterFaction = "Genestealer Cults",
                     ImgFile = "AcolyteLeader.PNG",
                     IsLimited = true,
                     Limit = 1,
                     IsSpecialist = false,
                     FighterSpecialization =  Fighter.Specializations.NONE,
                     FighterEquipmentList = new List<FighterWargear>
                     {


                     },
                     FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>
                    {

                    },
                     FighterRangedWeaponOptions = new List<FighterRangedWeapons>
                    {

                    },
                     FighterWargearOptions = new List<FighterWargear>
                    {

                    },
                     FighterSpecializationOptions = new List<Fighter.Specializations>
                    {
                        Fighter.Specializations.NONE,
                        Fighter.Specializations.LEADER,
                        Fighter.Specializations.COMBAT,
                        Fighter.Specializations.COMMS,
                        Fighter.Specializations.ZEALOT

                    }

                }

            };


            return fighters;


        }

        /// <summary>
        /// Creates a list of all wargear available to fighters.
        /// </summary>
        /// <returns></returns>
        public static List<FighterWargear> GenerateListOfWargear()
        {
            List<FighterWargear> gear = new List<FighterWargear>()
            {
                new FighterWargear(1000, 0, "Cult Icon", "Nearby models may reroll to-hit rolls of 1 in melee." )
            };

            foreach (FighterMeleeWeapons weapon in AvailableMeleeWeapons)
            {
                gear.Add(weapon as FighterWargear);
            }

            foreach (FighterRangedWeapons weapon in AvailableRangedWeapons)
            {
                gear.Add(weapon as FighterWargear);
            }


            return gear;
        }

        /// <summary>
        /// Creates a list of melee weapons
        /// </summary>
        /// <returns></returns>
        public static List<FighterMeleeWeapons> GenerateListOfMeleeWeapons()
        {
            List<FighterMeleeWeapons> weapons = new List<FighterMeleeWeapons>()
            {
                new FighterMeleeWeapons(2000, 0, "Cult Knife", "Type: Melee, S: User,  AP -, Damage: 1, A model may make 1 free attack with this weapon when they fight."),
                new FighterMeleeWeapons(2001, 0, "Rending Claw", "Type: Melee S: User,  AP -1, Damage: 1, To-wound rolls of 6+ are resolved at AP-4."),
                new FighterMeleeWeapons(2002, 1, "Bonesword", "Type: Melee S: User,  AP -2, Damage: 1"),
                new FighterMeleeWeapons(2003, 3, "Lash Whip and Bonesword", "Type: Melee S: User,  AP -1, Damage 1, This model may attack even if it is slain."),
                new FighterMeleeWeapons(2004, 5, "Heavy Rock Drill", "Type: Melee S:2X,  AP -3, Damage: 1, If a model suffers an unsaved wound from this weapon but is not slain, roll a die: The model suffers 1 mortal wound on a 2+. Repeat this process, subtracting 1 from the roll each time, until the model is slain or the roll is failed."),
                new FighterMeleeWeapons(2005, 3, "Heavy Rock Cutters", "Type: Melee S:2X,  AP -4, Damage: D3, Subtract 1 from hit rolls made with this weapon. If a model suffers one or more wounds from this weapon, roll a die. If the result exceeds the number of wounds the model has remaining, the model is slain.attack even if it is slain."),
                new FighterMeleeWeapons(2006, 3, "Heavy Rock Saw", "Type: MeleeS:2X,  AP -4, Damage: 2"),
                new FighterMeleeWeapons(2007, 5, "Demolition Charges", "Type: Grenade D6, S:8,  AP: -3, Damage: D3, This weapon can only be used once per game."), // Included here because it replaces a melee weapon
            };

            return weapons;
        }

        /// <summary>
        /// Creates a list of ranged weapons
        /// </summary>
        /// <returns></returns>
        public static List<FighterRangedWeapons> GenerateListOfRangedWeapons()
        {
            List<FighterRangedWeapons> weapons = new List<FighterRangedWeapons>()
            {
                new FighterRangedWeapons(3000, 0, "Blasting Charge", "Type: Grenade D6, S:3,  AP -, Damage: 1"),
                new FighterRangedWeapons(3001, 0, "Autopistol", "Type: Pistol 1 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                new FighterRangedWeapons(3002, 1, "Hand Flamer", "Type: Pistol D6 S:3,  AP -, Damage: 1, This weapon can be fired while in melee."),
                new FighterRangedWeapons(3003, 0, "Autogun", "Type: Rapid Fire, S:3,  AP -, Damage 1, This weapon fires an additional shot at half range."),
                new FighterRangedWeapons(3004, 0, "Shotgun", "Type: Assault 2, S:3,  AP -, Damage: 1, Add 1 to this weapon's strength at half range."),
                new FighterRangedWeapons(3005, 0, "Heavy Stubber", "Type: Heavy 3, S:4,  AP -, Damage: 1, Subtract 1 from hit rolls made with this weapon if the bearer moves."),
                new FighterRangedWeapons(3006, 0, "Mining Laser", "Type: Heavy 1, S:9,  AP -3, Damage: D3, Subtract 1 from hit rolls made with this weapon if the bearer moves"),
                new FighterRangedWeapons(3007, 0, "Seismic Cannon", "This weapon has two firing profiles. \n(Short Wave) Type: Heavy 6, S:3, AP-, Damage 1, To-wound rolls of 6+ are resolved at AP-4. Subtract 1 from hit rolls made with this weapon if the bearer moves.\n(Long Wave) Type: Heavy 3, S:6, AP-1, To-wound rolls of 6+ are resolved at AP-4. Subtract 1 from hit rolls made with this weapon if the bearer moves  "),
            };


            return weapons;
        }

        #endregion

        #region  HELPER METHODS

        /// <summary>
        /// Locates a fighter based on their type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Fighter FindFighterByType(string type)
        {

            return null;
        }


        /// <summary>
        /// Finds a wargear item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static FighterWargear FindWargearById(int id)
        {

            return null;
        }

        /// <summary>
        /// Finds a wargear item by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static FighterWargear FindWargearByName(string name)
        {

            return null;
        }



        #endregion
    }

}
