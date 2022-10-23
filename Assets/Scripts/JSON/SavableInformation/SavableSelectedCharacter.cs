using System;
[Serializable]
public class SavableSelectedCharacter : ISavable
{
   public string NameOfSelectedCharacter;
   public SavableSelectedCharacter() {}
   public SavableSelectedCharacter(string nameOfSelectedCharacter)
   {
     NameOfSelectedCharacter = nameOfSelectedCharacter;
   }
}
