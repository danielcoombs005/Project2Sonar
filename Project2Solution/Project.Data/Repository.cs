﻿using Project.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data
{
    public class Repository : IRepository
    {
        private readonly Entities.CobraKaiDbContext _db;

        public Repository(Entities.CobraKaiDbContext db)
        {
            _db = db;
        }
        //adds new journal
        public int CreateJournal(Project.Domain.Journal journal)
        {
            _db.Journals.Add(Mapper.Map(journal));
            return Save();
        }
        //adds new user
        public int CreatePerson(Project.Domain.Person person)
        {
            _db.People.Add(Mapper.Map(person));
            return Save();
        }
        //adds new playlist
        public int CreatePlayList(Project.Domain.PlayList playlist)
        {
            _db.Playlists.Add(Mapper.Map(playlist));
            return Save();
        }
        //adds new song
        public int CreateSong(Project.Domain.Song song)
        {
            _db.Songs.Add(Mapper.Map(song));
            return Save();
        }
        //deletes journal
        public int DeleteJournal(int id)
        {
            _db.Remove(_db.Journals.Find(id));
            return Save();
        }
        //deletes user
        public int DeletePerson(int id)
        {
            _db.Remove(_db.People.Find(id));
            return Save();
        }
        //deletes playlist
        public int DeletePlayList(int id)
        {
            _db.Remove(_db.Playlists.Find(id));
            return Save();
        }
        //deletes song
        public int DeleteSong(int id)
        {
            _db.Remove(_db.Songs.Find(id));
            return Save();
        }
        //gets journal by journal id
        public Journal GetJournalById(int id)
        {
            var jour = _db.Journals.Where(j => j.Id == id).FirstOrDefault();
            return Mapper.Map(jour);
        }
        //gets journal by title of journal
        public Journal GetJournalByTitle(string title)
        {
            var jour = _db.Journals.Where(j => j.Title == title).FirstOrDefault();
            return Mapper.Map(jour);
        }
        //gets all journals
        public IEnumerable<Journal> GetJournals()
        {
            return _db.Journals.Select(j => Mapper.Map(j));
        }
        //gets user by user id
        public Person GetPersonById(int id)
        {
            var per = _db.People.Where(p => p.Id == id).FirstOrDefault();
            return Mapper.Map(per);
        }//gets user by username
        public Person GetPersonByUsername(string user)
        {
            var per = _db.People.Where(u => u.Username == user).FirstOrDefault();
            return Mapper.Map(per);
        }
        //gets all users
        public IEnumerable<Person> GetPersons()
        {
            return _db.People.Select(p => Mapper.Map(p));
        }
        //gets playlist by playlist id
        public PlayList GetPlayListById(int id)
        {
            var plist = _db.Playlists.Where(pl => pl.Id == id).FirstOrDefault();
            return Mapper.Map(plist);
        }
        //gets playlist by title of playlist
        public PlayList GetPlayListByTitle(string title)
        {
            var plist = _db.Playlists.Where(pl => pl.Title == title).FirstOrDefault();
            return Mapper.Map(plist);
        }
        //gets all playlists
        public IEnumerable<PlayList> GetPlayLists()
        {
            return _db.Playlists.Select(pl => Mapper.Map(pl));
        }
        //gets song by song id
        public Song GetSongById(int id)
        {
            var song = _db.Songs.Where(s => s.Id == id).FirstOrDefault();
            return Mapper.Map(song);
        }
        //gets song by title of song
        public Song GetSongByTitle(string title, string artist)
        {
            var song = _db.Songs.Where(s => s.Title == title && s.Artist == artist).FirstOrDefault();
            return Mapper.Map(song);
        }
        //gets all songs
        public IEnumerable<Song> GetSongs()
        {
            return _db.Songs.Select(s => Mapper.Map(s));
        }
        //updates journal
        public int UpdateJournal(Journal journal)
        {
            _db.Entry(_db.Journals.Find(journal.Id)).CurrentValues.SetValues(Mapper.Map(journal));
            return Save();
        }
        //updates user
        public int UpdatePerson(Person person)
        {
            _db.Entry(_db.People.Find(person.Id)).CurrentValues.SetValues(Mapper.Map(person));
            return Save();
        }
        //updates playlist
        public int UpdatePlayList(PlayList playlist)
        {
            _db.Entry(_db.Playlists.Find(playlist.Id)).CurrentValues.SetValues(Mapper.Map(playlist));
            return Save();
        }
        //updates song
        public int UpdateSong(Song song)
        {
            _db.Entry(_db.Songs.Find(song.Id)).CurrentValues.SetValues(Mapper.Map(song));
            return Save();
        }
        //saves changes in database
        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}