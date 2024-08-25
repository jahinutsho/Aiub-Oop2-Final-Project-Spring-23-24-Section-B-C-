using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseMappingSystem1
{
    public class Course
    {
        public string CourseName { get; set; }
        public string Prerequisite1 { get; set; }
        public string Prerequisite2 { get; set; }
        public double cost {  get; set; }
    }

    public class CompletedCourse
    {
        public string CourseName { get; set; }
       public CompletedCourse (string courseName)
        {
            CourseName = courseName;
        }
    }

    public class Class1
    {
        List<CompletedCourse> completedCourses=new List<CompletedCourse>();
        public static List<string> GetIncompleteCourses(List<Course> courses, List<CompletedCourse> completedCourses)
        {
            List<string> incompleteCourseNames = new List<string>();
            

            foreach (Course course in courses)
            {
                
                // Check if the course is not completed
                if (!completedCourses.Any(cc => cc.CourseName == course.CourseName))
                {
                    
                    // Check if both prerequisites are completed
                    bool prerequisite1Completed = string.IsNullOrEmpty(course.Prerequisite1) ||
                                                  completedCourses.Any(cc => cc.CourseName == course.Prerequisite1);

                    bool prerequisite2Completed = string.IsNullOrEmpty(course.Prerequisite2) ||
                                                  completedCourses.Any(cc => cc.CourseName == course.Prerequisite2);

                    // If both prerequisites are completed, add the course to the list of incomplete courses
                    if (prerequisite1Completed && prerequisite2Completed)
                    {
                        incompleteCourseNames.Add(course.CourseName);
                    }
                }
            }

            return incompleteCourseNames;
        }
        public List<Course> getcourses1(List<CompletedCourse>cc)
        {
            List<Course> courses = new List<Course>
        {

            new Course { CourseName = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PHYSICS 1", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PHYSICS 1 LAB", Prerequisite1 = "", Prerequisite2 = "",cost=5500 },
            new Course { CourseName = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "INTRODUCTION TO PROGRAMMING", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "INTRODUCTION TO PROGRAMMING LAB", Prerequisite1 = "", Prerequisite2 = "",cost=5500 },
            new Course { CourseName = "INTRODUCTION TO COMPUTER STUDIES", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "DISCRETE MATHEMATICS", Prerequisite1 = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisite2 = "INTRODUCTION TO PROGRAMMING",cost=16500 },
            new Course { CourseName = "INTEGRAL  CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisite1 = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "OBJECT ORIENTED PROGRAMMING 1", Prerequisite1 = "INTRODUCTION TO PROGRAMMING", Prerequisite2 = "INTRODUCTION TO PROGRAMMING LAB" ,cost=16500},
            new Course { CourseName = "PHYSICS 2", Prerequisite1 = "PHYSICS 1", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PHYSICS 2 LAB", Prerequisite1 = "PHYSICS 1 LAB", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "ENGLISH WRITING SKILLS & COMMUNICATION", Prerequisite1 = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisite1 = "PHYSICS 1", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisite1 = "PHYSICS 1 LAB", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "CHEMISTRY", Prerequisite1 = "PHYSICS 2", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", Prerequisite1 = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "INTRODUCTION TO DATABASE", Prerequisite1 = "OBJECT ORIENTED PROGRAMMING 1", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "ELECTRONIC DEVICES LAB", Prerequisite1 = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "PRINCIPLES OF ACCOUNTING", Prerequisite1 = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "ELECTRONIC DEVICES", Prerequisite1 = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "DATA STRUCTURE", Prerequisite1 = "Discrete Mathematics", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 1" ,cost=16500},
            new Course { CourseName = "DATA STRUCTURE LAB", Prerequisite1 = "Discrete Mathematics", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 1",cost=5500 },
            new Course { CourseName = "COMPUTER AIDED DESIGN & DRAFTING", Prerequisite1 = "", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "ALGORITHMS", Prerequisite1 = "DATA STRUCTURE", Prerequisite2 = "DATA STRUCTURE LAB" },
            new Course { CourseName = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisite1 = "COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "OBJECT ORIENTED PROGRAMMING 2", Prerequisite1 = "INTRODUCTION TO DATABASE", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 1" ,cost=16500},
            new Course { CourseName = "OBJECT ORIENTED ANALYSIS AND DESIGN", Prerequisite1 = "INTRODUCTION TO DATABASE", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "BANGLADESH STUDIES", Prerequisite1 = "INTRODUCTION TO COMPUTER STUDIES", Prerequisite2 = "" , cost = 16500},
            new Course { CourseName = "DIGITAL LOGIC AND CIRCUITS", Prerequisite1 = "ELECTRONIC DEVICES", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "DIGITAL LOGIC AND CIRCUITS LAB", Prerequisite1 = "ELECTRONIC DEVICES LAB", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisite1 = "COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "THEORY OF COMPUTATION", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PRINCIPLES OF ECONOMICS", Prerequisite1 = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "BUSINESS COMMUNICATION", Prerequisite1 = "BANGLADESH STUDIES", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisite1 = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "DATA COMMUNICATION", Prerequisite1 = "DIGITAL LOGIC AND CIRCUITS", Prerequisite2 = "DIGITAL LOGIC AND CIRCUITS LAB",cost=16500 },
            new Course { CourseName = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisite1 = "DIGITAL LOGIC AND CIRCUITS", Prerequisite2 = "DIGITAL LOGIC AND CIRCUITS LAB",cost=16500 },
            new Course { CourseName = "SOFTWARE ENGINEERING", Prerequisite1 = "OBJECT ORIENTED ANALYSIS AND DESIGN", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 2" ,cost=16500},
            new Course { CourseName = "ARTIFICIAL INTELLIGENCE AND EXPERT SYS", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "COMPUTATIONAL STATISTICS AND PROBABILITY",cost=16500 },
            new Course { CourseName = "COMPUTER NETWORKS", Prerequisite1 = "DATA COMMUNICATION", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "COMPUTER ORGANIZATION AND ARCHITECTURE", Prerequisite1 = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "OPERATING SYSTEM", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "MICROPROCESSOR AND EMBEDDED SYSTEM" ,cost=16500},
            new Course { CourseName = "WEB TECHNOLOGIES", Prerequisite1 = "SOFTWARE ENGINEERING", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "ENGINEERING ETHICS", Prerequisite1 = "SOFTWARE ENGINEERING", Prerequisite2 = "MICROPROCESSOR AND EMBEDDED SYSTEM",cost=16500 },
            new Course { CourseName = "COMPILER DESIGN", Prerequisite1 = "THEORY OF COMPUTATION", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "COMPUTER GRAPHICS", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "MATRICES, VECTORS, FOURIER ANALYSIS",cost=16500 },
            new Course { CourseName = "ENGINEERING MANAGEMENT", Prerequisite1 = "ENGINEERING ETHICS", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "THESIS / PROJECT", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},

        };
            double d=0;
            List<CompletedCourse>c1= new List<CompletedCourse>();
            
            List<Course>courses1 = new List<Course>();
            foreach (Course c in courses)
            {
                   
                foreach (CompletedCourse c2 in cc)
                {
                    if (c.CourseName.Equals(c2.CourseName))
                    {
                        courses1.Add(c);
                    }
                }
            }
            
            return courses1;
        }
        public void setcomcourse(List<CompletedCourse> cp)
        {
            completedCourses=cp;
        }

        public List<string> courseset()
        {
            List<Course> courses = new List<Course>
        {

            new Course { CourseName = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PHYSICS 1", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PHYSICS 1 LAB", Prerequisite1 = "", Prerequisite2 = "",cost=5500 },
            new Course { CourseName = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "INTRODUCTION TO PROGRAMMING", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "INTRODUCTION TO PROGRAMMING LAB", Prerequisite1 = "", Prerequisite2 = "",cost=5500 },
            new Course { CourseName = "INTRODUCTION TO COMPUTER STUDIES", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "DISCRETE MATHEMATICS", Prerequisite1 = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisite2 = "INTRODUCTION TO PROGRAMMING",cost=16500 },
            new Course { CourseName = "INTEGRAL  CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisite1 = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "OBJECT ORIENTED PROGRAMMING 1", Prerequisite1 = "INTRODUCTION TO PROGRAMMING", Prerequisite2 = "INTRODUCTION TO PROGRAMMING LAB" ,cost=16500},
            new Course { CourseName = "PHYSICS 2", Prerequisite1 = "PHYSICS 1", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PHYSICS 2 LAB", Prerequisite1 = "PHYSICS 1 LAB", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "ENGLISH WRITING SKILLS & COMMUNICATION", Prerequisite1 = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisite1 = "PHYSICS 1", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisite1 = "PHYSICS 1 LAB", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "CHEMISTRY", Prerequisite1 = "PHYSICS 2", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", Prerequisite1 = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "INTRODUCTION TO DATABASE", Prerequisite1 = "OBJECT ORIENTED PROGRAMMING 1", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "ELECTRONIC DEVICES LAB", Prerequisite1 = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "PRINCIPLES OF ACCOUNTING", Prerequisite1 = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "ELECTRONIC DEVICES", Prerequisite1 = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "DATA STRUCTURE", Prerequisite1 = "Discrete Mathematics", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 1" ,cost=16500},
            new Course { CourseName = "DATA STRUCTURE LAB", Prerequisite1 = "Discrete Mathematics", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 1",cost=5500 },
            new Course { CourseName = "COMPUTER AIDED DESIGN & DRAFTING", Prerequisite1 = "", Prerequisite2 = "" ,cost=5500},
            new Course { CourseName = "ALGORITHMS", Prerequisite1 = "DATA STRUCTURE", Prerequisite2 = "DATA STRUCTURE LAB" },
            new Course { CourseName = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisite1 = "COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "OBJECT ORIENTED PROGRAMMING 2", Prerequisite1 = "INTRODUCTION TO DATABASE", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 1" ,cost=16500},
            new Course { CourseName = "OBJECT ORIENTED ANALYSIS AND DESIGN", Prerequisite1 = "INTRODUCTION TO DATABASE", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "BANGLADESH STUDIES", Prerequisite1 = "INTRODUCTION TO COMPUTER STUDIES", Prerequisite2 = "" , cost = 16500},
            new Course { CourseName = "DIGITAL LOGIC AND CIRCUITS", Prerequisite1 = "ELECTRONIC DEVICES", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "DIGITAL LOGIC AND CIRCUITS LAB", Prerequisite1 = "ELECTRONIC DEVICES LAB", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisite1 = "COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "THEORY OF COMPUTATION", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "PRINCIPLES OF ECONOMICS", Prerequisite1 = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "BUSINESS COMMUNICATION", Prerequisite1 = "BANGLADESH STUDIES", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisite1 = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "DATA COMMUNICATION", Prerequisite1 = "DIGITAL LOGIC AND CIRCUITS", Prerequisite2 = "DIGITAL LOGIC AND CIRCUITS LAB",cost=16500 },
            new Course { CourseName = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisite1 = "DIGITAL LOGIC AND CIRCUITS", Prerequisite2 = "DIGITAL LOGIC AND CIRCUITS LAB",cost=16500 },
            new Course { CourseName = "SOFTWARE ENGINEERING", Prerequisite1 = "OBJECT ORIENTED ANALYSIS AND DESIGN", Prerequisite2 = "OBJECT ORIENTED PROGRAMMING 2" ,cost=16500},
            new Course { CourseName = "ARTIFICIAL INTELLIGENCE AND EXPERT SYS", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "COMPUTATIONAL STATISTICS AND PROBABILITY",cost=16500 },
            new Course { CourseName = "COMPUTER NETWORKS", Prerequisite1 = "DATA COMMUNICATION", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "COMPUTER ORGANIZATION AND ARCHITECTURE", Prerequisite1 = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisite2 = "",cost=16500 },
            new Course { CourseName = "OPERATING SYSTEM", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "MICROPROCESSOR AND EMBEDDED SYSTEM" ,cost=16500},
            new Course { CourseName = "WEB TECHNOLOGIES", Prerequisite1 = "SOFTWARE ENGINEERING", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "ENGINEERING ETHICS", Prerequisite1 = "SOFTWARE ENGINEERING", Prerequisite2 = "MICROPROCESSOR AND EMBEDDED SYSTEM",cost=16500 },
            new Course { CourseName = "COMPILER DESIGN", Prerequisite1 = "THEORY OF COMPUTATION", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "COMPUTER GRAPHICS", Prerequisite1 = "ALGORITHMS", Prerequisite2 = "MATRICES, VECTORS, FOURIER ANALYSIS",cost=16500 },
            new Course { CourseName = "ENGINEERING MANAGEMENT", Prerequisite1 = "ENGINEERING ETHICS", Prerequisite2 = "" ,cost=16500},
            new Course { CourseName = "THESIS / PROJECT", Prerequisite1 = "", Prerequisite2 = "" ,cost=16500},

        };

          
             

            List<string> incompleteCourseNames = GetIncompleteCourses(courses, completedCourses);
            

            Console.WriteLine("Incomplete Courses:");
            foreach (string courseName in incompleteCourseNames)
            {
                Console.WriteLine(courseName);
            }
           
            
                
           
            return incompleteCourseNames;
        }
      


    }
    

}
