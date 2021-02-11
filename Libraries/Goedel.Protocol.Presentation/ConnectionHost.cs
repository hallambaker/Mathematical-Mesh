using Goedel.Utilities;

namespace Goedel.Protocol.Presentation {
    public class ConnectionHost : Connection {


        public byte[] SerializeChallenge(byte[] payload) {
            var plaintextWriter = new PacketWriter();


            var writer = new PacketWriterAesGcm();
            writer.Write(PlaintextPacketType.ClientExchange);
            writer.Encrypt(Key, plaintextWriter);

            return writer.Packet;
            }

        public byte[] SerializeComplete(byte[] payload) {
            var plaintextWriter = new PacketWriter();


            var writer = new PacketWriterAesGcm();
            writer.Write(PlaintextPacketType.ClientExchange);
            writer.Encrypt(Key, plaintextWriter);

            return writer.Packet;
            }

        }

    }
