using System.Diagnostics.Contracts;

namespace Yggdrasil.Interfaces.Models;

[GenerateSerializer]
public class DbDigimonModel
{
    [Id(0)]
    public int Id { get; set; }
    
    [Id(1)]
    public int CharacterId { get; set; }
    
    [Id(2)]
    public string Name { get; set; }

    [Id(3)]
    public int Level { get; set; } = 1;

    [Id(4)]
    public int Type { get; set; } = 31003;

    [Id(5)]
    public int Model { get; set; } = 31003;

    [Id(6)]
    public int Exp { get; set; } = 0;
    
    [Id(7)]
    public int SkillPoints { get; set; } = 0;

    [Id(8)]
    public int SkillLevel { get; set; } = 1;
    
    [Id(9)]
    public int[] Skills { get; set; }
    
    [Id(10)]
    public int SkillGrade { get; set; }

    [Id(11)]
    public int DigiSize { get; set; } = 15000;

    [Id(12)]
    public int DigiScale { get; set; } = 3;

    [Id(13)]
    public int MaxHp { get; set; } = 100;

    [Id(14)]
    public int Hp { get; set; } = 100;

    [Id(15)]
    public int MaxDs { get; set; } = 100;

    [Id(16)]
    public int Ds { get; set; } = 100;

    [Id(17)]
    public int De { get; set; } = 0;

    [Id(18)]
    public int At { get; set; } = 0;

    [Id(19)]
    public int Bl { get; set; } = 0;

    [Id(20)]
    public int Sync { get; set; } = 0;

    [Id(21)]
    public int Ht { get; set; } = 0;

    [Id(22)]
    public int Ev { get; set; } = 0;

    [Id(23)]
    public int Cr { get; set; } = 0;

    [Id(24)]
    public int Ms { get; set; } = 580;

    [Id(25)]
    public int As { get; set; } = 3000;
    
    [Id(26)]
    public string Forms { get; set; }

    [Id(27)]
    public int UnlockedLevels { get; set; } = 0;
}