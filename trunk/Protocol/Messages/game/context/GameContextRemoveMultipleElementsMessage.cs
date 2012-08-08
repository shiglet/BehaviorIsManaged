// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'GameContextRemoveMultipleElementsMessage.xml' the '27/06/2012 15:55:00'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class GameContextRemoveMultipleElementsMessage : NetworkMessage
	{
		public const uint Id = 252;
		public override uint MessageId
		{
			get
			{
				return 252;
			}
		}
		
		public int[] id;
		
		public GameContextRemoveMultipleElementsMessage()
		{
		}
		
		public GameContextRemoveMultipleElementsMessage(int[] id)
		{
			this.id = id;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)id.Count());
			foreach (var entry in id)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			id = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(id as int[])[i] = reader.ReadInt();
			}
		}
	}
}
