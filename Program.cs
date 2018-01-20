using System;

namespace ProblemCMain
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double Table_width, Table_length, radius;
            PointOfBall Ball1_Postion = new PointOfBall();
            PointOfBall Ball2_Postion = new PointOfBall();
            PointOfBall Ball3_Postion = new PointOfBall();
            double height = 0;

            // Constant values
            double PI_Value = 3.14159265358979323846;
            bool ShotPossible = true;


            // Take input
            string[] width_and_height = Console.ReadLine().Split(' ');
            Table_width = float.Parse(width_and_height[0]);
            Table_length = float.Parse(width_and_height[1]);

            string[] ball_positions = Console.ReadLine().Split(' ');
            if (ball_positions.Length != 8)
            {
                Console.WriteLine("please provide 8 positions");
                return;
            }

            radius = float.Parse(ball_positions[0]);

            Ball1_Postion.x = Double.Parse(ball_positions[1]);
            Ball1_Postion.y = Double.Parse(ball_positions[2]);

            Ball2_Postion.x = Double.Parse(ball_positions[3]);
            Ball2_Postion.y = Double.Parse(ball_positions[4]);

            Ball3_Postion.x = Double.Parse(ball_positions[5]);
            Ball3_Postion.y = Double.Parse(ball_positions[6]);

            height = Double.Parse(ball_positions[7]);

            // Impossible shot conditions
            if (Ball1_Postion.x < Ball2_Postion.x)
            {
                ShotPossible = false;

            }
            if (Ball1_Postion.y > Ball2_Postion.y)
            {
                ShotPossible = false;

            }
            if (Ball1_Postion.x > Ball3_Postion.x)
            {
                ShotPossible = false;


            }
            if (Ball1_Postion.y > Ball3_Postion.y)
            {
                ShotPossible = false;

            }

            // Calculating angels, how cue hits ball-1,ball-2,ball-3; major math trignometric formula

            // Math.Atan represents tangent angel; math.cos is cosin angle


            double Ball2_Angel = PI_Value - Math.Atan((Table_length - Ball2_Postion.y) / (Ball2_Postion.x));
            double Cue2_Impact_Angel = PI_Value - Ball2_Angel;

            // Cue ball position
            PointOfBall Cue2_Impact = new PointOfBall();
            Cue2_Impact.x = Ball2_Postion.x + 2 * radius * Math.Cos(Cue2_Impact_Angel);
            Cue2_Impact.y = Ball2_Postion.y - 2 * radius * Math.Sin(Cue2_Impact_Angel);


            // Ball-3 also has an angel, so here finds ball3- angel using math formula
            double Ball3_Angel = Math.Atan((Table_length - Ball3_Postion.y) / (Table_width - Ball3_Postion.x));


            // Here finds points ball-3
            PointOfBall Ball1_Impact = new PointOfBall();
            Ball1_Impact.x = Ball3_Postion.x - 2 * radius * Math.Cos(Ball3_Angel);
            Ball1_Impact.y = Ball3_Postion.y - 2 * radius * Math.Sin(Ball3_Angel);

            // Here ball 1 angel
            double Ball1_Angel = Math.Atan((Ball1_Impact.y - Ball1_Postion.y) / (Ball1_Impact.x - Ball1_Postion.x));


            // Cue updated finding postion with angel sin, cos
            PointOfBall CueUpdate_Impact = new PointOfBall();
            CueUpdate_Impact.x = Ball1_Postion.x - 2 * radius * Math.Cos(Ball1_Angel);
            CueUpdate_Impact.y = Ball1_Postion.y - 2 * radius * Math.Sin(Ball1_Angel);


            // Cue updated postion with X,Y coordinates
            double Cue_X = CueUpdate_Impact.x - Cue2_Impact.x;
            double Cue_Y = Cue2_Impact.y - CueUpdate_Impact.y;

            // Cue comes off of ball 1 at angel this
            double Cue_Ball1_Ball2_impact_Angel = PI_Value - Math.Atan(Cue_Y / Cue_X);

            // Calculating the final angle θ to shot the balls
            double Ball1_N_Angel = Ball1_Angel + PI_Value / 2;
            double Phase1_Value = Cue_Ball1_Ball2_impact_Angel - Ball1_N_Angel;
            double Phase2_Value = PI_Value - Ball1_N_Angel;
            double Angel = PI_Value - Phase1_Value - Phase2_Value;
            double PoolTable = (CueUpdate_Impact.y - height) / (Math.Tan(PI_Value - Angel));
            PoolTable = PoolTable + CueUpdate_Impact.x;


            if (PoolTable < radius)
                ShotPossible = false;
            if (PoolTable > Table_width - radius)
                ShotPossible = false;

            if (ShotPossible == true)
            {
                Angel = Angel * 180 / PI_Value;
                string Final_Angel, Final_PoolTable;
                Final_Angel = Angel.ToString();
                Final_PoolTable = PoolTable.ToString();
                Final_Angel = String.Format("{0:0.00}", Angel);
                Final_PoolTable = String.Format("{0:0.00}", PoolTable);
                Console.WriteLine("{0} {1}", Final_PoolTable, Final_Angel);
            }
            else
            {
                Console.WriteLine("Impossible");
            }
            Console.ReadLine();

        }
    }
    class PointOfBall
    {
        public double x = 0.0, y = 0.0;
    };

}