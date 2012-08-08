// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'CharactersListWithModificationsMessage.xml' the '27/06/2012 15:54:58'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace BiM.Protocol.Messages
{
	public class CharactersListWithModificationsMessage : CharactersListMessage
	{
		public const uint Id = 6120;
		public override uint MessageId
		{
			get
			{
				return 6120;
			}
		}
		
		public Types.CharacterToRecolorInformation[] charactersToRecolor;
		public int[] charactersToRename;
		public int[] unusableCharacters;
		
		public CharactersListWithModificationsMessage()
		{
		}
		
		public CharactersListWithModificationsMessage(bool hasStartupActions, Types.CharacterBaseInformations[] characters, Types.CharacterToRecolorInformation[] charactersToRecolor, int[] charactersToRename, int[] unusableCharacters)
			 : base(hasStartupActions, characters)
		{
			this.charactersToRecolor = charactersToRecolor;
			this.charactersToRename = charactersToRename;
			this.unusableCharacters = unusableCharacters;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUShort((ushort)charactersToRecolor.Count());
			foreach (var entry in charactersToRecolor)
			{
				entry.Serialize(writer);
			}
			writer.WriteUShort((ushort)charactersToRename.Count());
			foreach (var entry in charactersToRename)
			{
				writer.WriteInt(entry);
			}
			writer.WriteUShort((ushort)unusableCharacters.Count());
			foreach (var entry in unusableCharacters)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			int limit = reader.ReadUShort();
			charactersToRecolor = new Types.CharacterToRecolorInformation[limit];
			for (int i = 0; i < limit; i++)
			{
				(charactersToRecolor as Types.CharacterToRecolorInformation[])[i] = new Types.CharacterToRecolorInformation();
				(charactersToRecolor as Types.CharacterToRecolorInformation[])[i].Deserialize(reader);
			}
			limit = reader.ReadUShort();
			charactersToRename = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(charactersToRename as int[])[i] = reader.ReadInt();
			}
			limit = reader.ReadUShort();
			unusableCharacters = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(unusableCharacters as int[])[i] = reader.ReadInt();
			}
		}
	}
}
