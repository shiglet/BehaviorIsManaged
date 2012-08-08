// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'CharacterCreationRequestMessage.xml' the '27/06/2012 15:54:58'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class CharacterCreationRequestMessage : NetworkMessage
	{
		public const uint Id = 160;
		public override uint MessageId
		{
			get
			{
				return 160;
			}
		}
		
		public string name;
		public sbyte breed;
		public bool sex;
		public int[] colors;
		
		public CharacterCreationRequestMessage()
		{
		}
		
		public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, int[] colors)
		{
			this.name = name;
			this.breed = breed;
			this.sex = sex;
			this.colors = colors;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			foreach (var entry in colors)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			breed = reader.ReadSByte();
			if ( breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Steamer )
			{
				throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Steamer");
			}
			sex = reader.ReadBoolean();
			colors = new int[5];
			for (int i = 0; i < 5; i++)
			{
				(colors as int[])[i] = reader.ReadInt();
			}
		}
	}
}
