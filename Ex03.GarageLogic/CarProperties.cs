using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum Color
    {
        Gray,
        Blue,
        White,
        Black
    }
    public struct CarProperties
    {
        Color m_Color;
        int m_numOfDoors;

        public CarProperties(Color i_Color, int i_numOfDoor)
        {
            m_Color = i_Color;
            m_numOfDoors = i_numOfDoor;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendFormat("Color: {0}. Number of doors: {1}.", m_Color, m_numOfDoors);
            toString.AppendLine();

            return toString.ToString();
        }
    }
}
