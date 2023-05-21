using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Views.Alunos
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DeleteModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public AlunoModel AlunoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AlunoModel == null)
            {
                return NotFound();
            }

            var alunomodel = await _context.AlunoModel.FirstOrDefaultAsync(m => m.ID == id);

            if (alunomodel == null)
            {
                return NotFound();
            }
            else 
            {
                AlunoModel = alunomodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AlunoModel == null)
            {
                return NotFound();
            }
            var alunomodel = await _context.AlunoModel.FindAsync(id);

            if (alunomodel != null)
            {
                AlunoModel = alunomodel;
                _context.AlunoModel.Remove(AlunoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
