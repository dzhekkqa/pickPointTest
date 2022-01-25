using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pickPointTest.Contracts.Requests;
using pickPointTest.Data;
using pickPointTest.Models;

namespace pickPointTest.Services
{
    public class PostamatService: IPostamatService
    {

        private readonly DataContext _dataContext;

        public PostamatService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Если постаматов нет
        public void PostamatsGenerator()
        {
            for (var i = 0; i < 5; i++)
            {
                _dataContext.Postamats.AddAsync(new Postamat
                {
                    pNumber = NumberGenerator(),
                    pAddress = AddressGenerator(),
                    pStatus = StatusGenerator()
                });
            }
            _dataContext.SaveChangesAsync();
        }

        public string NumberGenerator()
        {
            Random rd = new Random();
            int firstPart = rd.Next(1000, 9999);
            int secondPart = rd.Next(100, 999);
            return firstPart.ToString() + "-" + secondPart.ToString();
        }

        public string AddressGenerator()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string address = "";
            Random rand = new Random();

            for (int j = 1; j <= 5; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                address += letters[letter_num];
            }                
            return address;
        }

        public bool StatusGenerator()
        {
            Random rand = new Random();
            var result = rand.Next(0, 1);
            return result == 1 ? true : false;
        }

        public async Task<Postamat> GetPostamatInfo(PostamatInfoRequest pir)
        {
            return await _dataContext.Postamats
                .Where(x => x.pNumber == pir.postamatNumber)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Postamat>> GetEnablePostamats()
        {   
            if (_dataContext.Postamats.Count() <= 0)
            {
                PostamatsGenerator();
            }
            return await _dataContext.Postamats
                    .OrderBy(x => x.pNumber)
                    .Where(x => x.pStatus == true)
                    .ToListAsync();
        }
    }
}
