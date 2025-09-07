class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Hitpoints { get; set; }
    public int Level { get; set; }
    public string[] Equipment { get; set; }

    public Character(string Name, string Class, int Level, int Hitpoints, string[] Equipment)
    {
        this.Name = Name;
        this.Class = Class;
        this.Level = Level;
        this.Hitpoints = Hitpoints;
        this.Equipment = Equipment;
    }

    public override string ToString()
    {
        return (
            $"Name: {this.Name.Replace("\"", "")}\n" +
            $"Class: {this.Class}\n" + 
            $"Level: {this.Level}\n" + 
            $"Hitpoints: {this.Hitpoints}\n" +
            $"Equipment: {String.Join("|", this.Equipment).Replace("|", ", ")}"
        );
    }
}