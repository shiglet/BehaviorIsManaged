// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ExchangeObjectTransfertListFromInvMessage.xml' the '27/06/2012 15:55:10'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class ExchangeObjectTransfertListFromInvMessage : NetworkMessage
	{
		public const uint Id = 6183;
		public override uint MessageId
		{
			get
			{
				return 6183;
			}
		}
		
		public int[] ids;
		
		public ExchangeObjectTransfertListFromInvMessage()
		{
		}
		
		public ExchangeObjectTransfertListFromInvMessage(int[] ids)
		{
			this.ids = ids;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)ids.Count());
			foreach (var entry in ids)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			ids = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(ids as int[])[i] = reader.ReadInt();
			}
		}
	}
}
