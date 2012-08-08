// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ObjectAveragePricesMessage.xml' the '27/06/2012 15:55:08'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class ObjectAveragePricesMessage : NetworkMessage
	{
		public const uint Id = 6335;
		public override uint MessageId
		{
			get
			{
				return 6335;
			}
		}
		
		public short[] ids;
		public int[] avgPrices;
		
		public ObjectAveragePricesMessage()
		{
		}
		
		public ObjectAveragePricesMessage(short[] ids, int[] avgPrices)
		{
			this.ids = ids;
			this.avgPrices = avgPrices;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)ids.Count());
			foreach (var entry in ids)
			{
				writer.WriteShort(entry);
			}
			writer.WriteUShort((ushort)avgPrices.Count());
			foreach (var entry in avgPrices)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			ids = new short[limit];
			for (int i = 0; i < limit; i++)
			{
				(ids as short[])[i] = reader.ReadShort();
			}
			limit = reader.ReadUShort();
			avgPrices = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(avgPrices as int[])[i] = reader.ReadInt();
			}
		}
	}
}
