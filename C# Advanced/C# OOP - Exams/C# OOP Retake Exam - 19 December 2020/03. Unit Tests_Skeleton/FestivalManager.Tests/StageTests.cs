// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		private Performer performer;
		private Song song;
		private Stage stage;

		[SetUp]
		public void Setup()
        {
			performer = new Performer("Ivan", "Ivanov", 30);
			song = new Song("sexyLady", new TimeSpan(0, 1, 30));
			stage = new Stage();
        }
		//Can not be null!

		[Test]
	    public void PerformerValidate()
	    {
			Assert.IsNotNull(performer);
		}

		[Test]
		public void SongValidate()
		{
			Assert.IsNotNull(song);
		}

		[Test]
		public void AddPerformer()
		{
			stage.AddPerformer(performer);
			Assert.AreEqual(stage.Performers.Count, 1);
		}

		[Test]
		public void Addperformer2()
		{
			Exception ex = Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(new Performer("pesho", "idk", 12));
			});

			Assert.AreEqual(ex.Message, "You can only add performers that are at least 18.");
		}
		
		[Test]
		public void AddSong()
		{
			Exception ex = Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(new Song("idk", new TimeSpan(0, 0, 30)));
			});

			Assert.AreEqual(ex.Message, "You can only add songs that are longer than 1 minute.");
		}

		[Test]
		public void AddSong1()
		{
			stage.AddSong(song);
			
		}

		[Test]
		public void AddSongToPerformer()
		{
			stage.AddPerformer(performer);
			stage.AddSong(song);
			performer.SongList.Add(song);

			Assert.AreEqual(performer.SongList.Count, 1);
		}

		[Test]
		public void Play()
		{
			stage.AddPerformer(performer);
			stage.AddSong(song);
			performer.SongList.Add(song);

			string result = $"{this.stage.Performers.Count} performers played {performer.SongList.Count} songs";

			Assert.AreEqual($"{this.stage.Performers.Count} performers played {performer.SongList.Count} songs", stage.Play());
		}
	}
}