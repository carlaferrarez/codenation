using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        // frases aleatorias
        // retorna o quote inteiro
        // dentro do random integer, preciso saber o máximo de quotes que posso ter, para adicionar o parametro max

        public Quote GetAnyQuote()

        {
            var query = _context.Quotes.ToList();

            if (query.Count() == 0)
                return null;

            int aleatorio = _randomService.RandomInteger(query.Count());

            var result = query.Skip(aleatorio).FirstOrDefault();
            return result;
        }

        // frases aleatorias de um ator em especifico
        public Quote GetAnyQuote(string actor)
        {
            var query = _context.Quotes.ToList();

            if (query.Count() == 0)
                return null;

            int aleatorio = _randomService.RandomInteger(query.Count());

            var result = query.Where(x => x.Actor == actor).Skip(aleatorio).FirstOrDefault();

            if (result != null)
                return result;
            return null;
        }
    }
}