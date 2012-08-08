// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'NewMailMessage.xml' the '27/06/2012 15:55:14'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace BiM.Protocol.Messages
{
	public class NewMailMessage : MailStatusMessage
	{
		public const uint Id = 6292;
		public override uint MessageId
		{
			get
			{
				return 6292;
			}
		}
		
		public int[] sendersAccountId;
		
		public NewMailMessage()
		{
		}
		
		public NewMailMessage(short unread, short total, int[] sendersAccountId)
			 : base(unread, total)
		{
			this.sendersAccountId = sendersAccountId;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUShort((ushort)sendersAccountId.Count());
			foreach (var entry in sendersAccountId)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			int limit = reader.ReadUShort();
			sendersAccountId = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(sendersAccountId as int[])[i] = reader.ReadInt();
			}
		}
	}
}
