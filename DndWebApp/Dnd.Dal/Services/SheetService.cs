using AutoMapper;
using Dnd.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace Dnd.Dal.Services
{
    public class SheetService
    {
        private DndContext db;
        private IMapper mapper;
        public SheetService(DndContext dbContext)
        {
            this.db = dbContext;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Entities.CharacterSheet, Dto.CharacterSheet>().ReverseMap();
                cfg.CreateMap<Entities.FeatureSkill, Dto.FeatureSkill>().ReverseMap();
                cfg.CreateMap<Entities.Weapon, Dto.Weapon>().ReverseMap();
                cfg.CreateMap<Entities.Spell, Dto.Spell>().ReverseMap();
                });
            mapper = config.CreateMapper();
        }

        public List<string> AllSheetByName(string username)
        {
            var user = db.Users.Include(u => u.CharacterSheets).FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return null;
            return user.CharacterSheets.Select(s => s.CharacterName).ToList();
        }

        public bool UpdateSheet(string username, string charactername, Dto.CharacterSheet sheet)
        {
            var user = db.Users.Include(u => u.CharacterSheets)
                               .ThenInclude(s => s.FeatureSkills)
                               .Include(u => u.CharacterSheets)
                               .ThenInclude(s => s.Spells)
                               .Include(u => u.CharacterSheets)
                               .ThenInclude(s => s.Weapons).FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return false;
            var entitysheet = mapper.Map<Entities.CharacterSheet>(sheet);
            var updatesheet = user.CharacterSheets.FirstOrDefault(cs => RemoveWhitespace(cs.CharacterName.ToLower()) == RemoveWhitespace(charactername.ToLower()));
            if (updatesheet == null)
                return false;
            user.CharacterSheets.Remove(updatesheet);
            user.CharacterSheets.Add(entitysheet);
            db.SaveChanges();
            return true;
        }

        public Dto.CharacterSheet FindSheetByName(string username, string charactername)
        {
            var sheet =  db.Users.Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.FeatureSkills)
                                .Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.Spells)
                                .Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.Weapons).FirstOrDefault(u => u.UserName == username)
                                .CharacterSheets.Where(c => RemoveWhitespace(c.CharacterName.ToLower()) == RemoveWhitespace(charactername.ToLower()))
                                .FirstOrDefault();
            return mapper.Map<Dto.CharacterSheet>(sheet);
        }

        public Entities.CharacterSheet AddCharacterSheet(string username, Dto.CharacterSheet sheet)
        {
            var entitysheet = mapper.Map<Entities.CharacterSheet>(sheet);
            var user = db.Users.Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.FeatureSkills)
                                .Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.Spells)
                                .Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.Weapons).FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return null;
            user.CharacterSheets.Add(entitysheet);
            db.SaveChanges();
            return entitysheet;
        }

        public bool DeleteCharacterSheet(string username, string charactername)
        {
            var user = db.Users.Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.FeatureSkills)
                                .Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.Spells)
                                .Include(u => u.CharacterSheets)
                                .ThenInclude(s => s.Weapons).FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return false;
            user.CharacterSheets.RemoveAll(c => RemoveWhitespace(c.CharacterName.ToLower()) == RemoveWhitespace(charactername.ToLower()));
            db.SaveChanges();
            return true;
        }

        private string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
