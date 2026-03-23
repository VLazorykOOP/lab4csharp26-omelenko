using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4CSharp;
public struct SportTeamStruct
{
    public string Name;
    public string City;
    public int PlayersCount;
    public int Points;

    public override string ToString() => $"{Name} ({City}) - Гравців: {PlayersCount}, Очки: {Points}";
}
