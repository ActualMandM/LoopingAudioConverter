using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGAudio.Codecs.CriHca;
using VGAudio.Containers.Hca;

namespace LoopingAudioConverter.VGAudioOptions {
	public class HcaOptions : VGAudioOptionsBase<HcaConfiguration> {
		public CriHcaQuality Quality { get; set; }

		public bool LimitBitrate { get; set; }

		public int Bitrate { get; set; }

		public ulong? KeyCode { get; set; }

		public ushort? AwbHash { get; set; }

		public override HcaConfiguration Configuration => new HcaConfiguration {
			Bitrate = Bitrate,
			EncryptionKey = KeyCode is ulong k ? new CriHcaKey(AwbHash is ushort h ? k * (((ulong)h << 16) | (ushort)(~h + 2)) : k) : null,
			LimitBitrate = LimitBitrate,
			TrimFile = TrimFile,
			Quality = Quality
		};
	}
}
