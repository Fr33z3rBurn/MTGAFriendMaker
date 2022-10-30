using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGAFriendMaker
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class CheckpointConfiguration
	{
	}

	public class ClipsConfiguration
	{
	}

	public class ConnectionInfo
	{
		public string connectionState { get; set; }
	}

	public class GameRoomConfig
	{
		public string eventId { get; set; }
		public List<ReservedPlayer> reservedPlayers { get; set; }
		public string matchId { get; set; }
		public GreConfig greConfig { get; set; }
		public string greHostLoggerLevel { get; set; }
		public int joinRoomTimeoutSecs { get; set; }
		public int playerDisconnectTimeoutSecs { get; set; }
	}

	public class GameRoomInfo
	{
		public GameRoomConfig gameRoomConfig { get; set; }
		public string stateType { get; set; }
		public List<Player> players { get; set; }
	}

	public class GameStateRedactorConfiguration
	{
		public bool enableRedaction { get; set; }
		public bool enableForceDiff { get; set; }
	}

	public class GreConfig
	{
		public GameStateRedactorConfiguration gameStateRedactorConfiguration { get; set; }
		public ClipsConfiguration clipsConfiguration { get; set; }
		public CheckpointConfiguration checkpointConfiguration { get; set; }
	}

	public class MatchGameRoomStateChangedEvent
	{
		public GameRoomInfo gameRoomInfo { get; set; }
	}

	public class Player
	{
		public string userId { get; set; }
		public int systemSeatId { get; set; }
	}

	public class ReservedPlayer
	{
		public string userId { get; set; }
		public string playerName { get; set; }
		public int systemSeatId { get; set; }
		public int teamId { get; set; }
		public ConnectionInfo connectionInfo { get; set; }
		public string courseId { get; set; }
		public string sessionId { get; set; }
		public string platformId { get; set; }
	}

	public class Root
	{
		public string transactionId { get; set; }
		public int requestId { get; set; }
		public string timestamp { get; set; }
		public MatchGameRoomStateChangedEvent matchGameRoomStateChangedEvent { get; set; }
	}


}
