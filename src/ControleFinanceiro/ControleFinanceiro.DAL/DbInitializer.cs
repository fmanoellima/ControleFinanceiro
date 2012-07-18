using System;
using System.Collections.Generic;
using System.Data.Entity;
using ControleFinanceiro.DAL.Entities;

namespace ControleFinanceiro.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<CFDbContext>
    {

        protected override void Seed(CFDbContext context)
        {

            var categorias = new List<Categoria>
                                     {
                                         new Categoria {Nome = "Automóvel"},
                                         new Categoria {Nome = "Estudos"},
                                         new Categoria {Nome = "Diversos"},
                                         new Categoria {Nome = "Familia"},
                                         new Categoria {Nome = "Impostos"},
                                         new Categoria {Nome = "Investimentos"},
                                         new Categoria {Nome = "Lazer"},
                                         new Categoria {Nome = "Moradia"},
                                         new Categoria {Nome = "Pessoal"},
                                         new Categoria {Nome = "Receitas"},
                                         new Categoria {Nome = "Saúde"},
                                         new Categoria {Nome = "Trabalho"},
                                         new Categoria {Nome = "Transações Financeiras"}
                                     };
            categorias.ForEach(i => i.DataCadastro = DateTime.Now);
            categorias.ForEach(i => context.Categorias.Add(i));
            context.SaveChanges();

            var subCategorias = new List<Subcategoria>
                                     {
                                         //Categoria - Automóvel
                                         new Subcategoria {Nome = "Combustível",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Estacionamento",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "IPVA",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Licenciamento",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Manutenção",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Multa",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Outros",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Pedágio",Categoria = categorias[0]},
                                         new Subcategoria {Nome = "Seguro",Categoria = categorias[0]},

                                         //Categoria - Estudos
                                         new Subcategoria {Nome = "Cursos",Categoria = categorias[1]},
                                         new Subcategoria {Nome = "Faculdade",Categoria = categorias[1]},
                                         new Subcategoria {Nome = "Livros",Categoria = categorias[1]},

                                         //Categoria - Diversos
                                         new Subcategoria {Nome = "Banda",Categoria = categorias[2]},
                                         new Subcategoria {Nome = "Doação",Categoria = categorias[2]},
                                         new Subcategoria {Nome = "Outros",Categoria = categorias[2]},
                                         new Subcategoria {Nome = "Presentes",Categoria = categorias[2]},
                                         new Subcategoria {Nome = "Veterinário",Categoria = categorias[2]},

                                         //Categoria - Família
                                         new Subcategoria {Nome = "Ajuda",Categoria = categorias[3]},
                                         new Subcategoria {Nome = "Confraternizações",Categoria = categorias[3]},
                                         new Subcategoria {Nome = "Presentes",Categoria = categorias[3]},

                                         //Categoria - Impostos
                                         new Subcategoria {Nome = "IOF",Categoria = categorias[4]},
                                         new Subcategoria {Nome = "Alíquota IR",Categoria = categorias[4]},
                                         new Subcategoria {Nome = "Tarifa Bancaria",Categoria = categorias[4]},
                                         new Subcategoria {Nome = "Outras Tarifas",Categoria = categorias[4]},

                                          //Categoria - Investimentos
                                          new Subcategoria {Nome = "Ações",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Dividendos",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Fundos",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Pagamento de Juros",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Perdas",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Poupança",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Rendimentos",Categoria = categorias[5]},
                                          new Subcategoria {Nome = "Títulos",Categoria = categorias[5]},

                                          //Categoria - Lazer
                                          new Subcategoria {Nome = "Esportes",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Hotéis",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Livros e Revistas",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Namoro",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Outros",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Passeios",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Restaurantes",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Shows, Bares e Boates",Categoria = categorias[6]},
                                          new Subcategoria {Nome = "Vídeos e Cinemas",Categoria = categorias[6]},

                                          //Categoria - Moradia
                                          new Subcategoria {Nome = "Aluguel",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Prestação Imóvel",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Apto. CPS",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Condomínio",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Água",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Internet",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "IPTU",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Limpeza",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Energia Elétrica",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Outros",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Supermercado",Categoria = categorias[7]},
                                          new Subcategoria {Nome = "Telefone",Categoria = categorias[7]},

                                          //Categoria - Pessoal
                                          new Subcategoria {Nome = "Academia",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Alimentação",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Celular",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Compras",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Informática",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Esportes",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Higiene Pessoal",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Outros",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Transporte Urbano",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Vestuário",Categoria = categorias[8]},
                                          new Subcategoria {Nome = "Viagens",Categoria = categorias[8]},

                                           //Categoria - Receitas
                                          new Subcategoria {Nome = "13º Salário",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Aluguel",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Bônus",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Férias",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Horas Extras",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Outros",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Reembolso",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Restituição IR",Categoria = categorias[9]},
                                          new Subcategoria {Nome = "Salários",Categoria = categorias[9]},

                                          //Categoria - Saúde
                                          new Subcategoria {Nome = "Dentista",Categoria = categorias[10]},
                                          new Subcategoria {Nome = "Medicamentos",Categoria = categorias[10]},
                                          new Subcategoria {Nome = "Consulta Médica",Categoria = categorias[10]},
                                          new Subcategoria {Nome = "Oculista",Categoria = categorias[10]},
                                          new Subcategoria {Nome = "Plano de Saúde",Categoria = categorias[10]},
                                          new Subcategoria {Nome = "Outros",Categoria = categorias[10]},

                                          //Categoria - Trabalho
                                          new Subcategoria {Nome = "Não Reembolsáveis",Categoria = categorias[11]},
                                          new Subcategoria {Nome = "Reembolsáveis",Categoria = categorias[11]},

                                          //Categoria - Transações Financeiras
                                          new Subcategoria {Nome = "Saldo de Abertura",Categoria = categorias[12]},
                                          new Subcategoria {Nome = "Simples Transferência",Categoria = categorias[12]}

                                     };
            subCategorias.ForEach(i => i.DataCadastro = DateTime.Now);
            subCategorias.ForEach(i => context.Subcategorias.Add(i));
            context.SaveChanges();





            var tiposPagamento = new List<TipoPagamento>
                                     {
                                         new TipoPagamento {Nome = "Banco"},
                                         new TipoPagamento {Nome = "Cartão Crédito"},
                                         new TipoPagamento {Nome = "Cartão Débito"},
                                         new TipoPagamento {Nome = "Cheque"},
                                         new TipoPagamento {Nome = "Dinheiro"},
                                         new TipoPagamento {Nome = "Transação pela Internet"},
                                     };
            tiposPagamento.ForEach(i => i.DataCadastro = DateTime.Now);
            tiposPagamento.ForEach(i => context.TiposPagamento.Add(i));
            context.SaveChanges();

            var tiposConta = new List<TipoConta>
                                     {
                                         new TipoConta {Nome = "Conta Corrente"},
                                         new TipoConta {Nome = "Poupança"},
                                         new TipoConta {Nome = "Títulos Governo"},
                                         new TipoConta {Nome = "CDB"},
                                         new TipoConta {Nome = "Fundos"},
                                         new TipoConta {Nome = "Ações"}
                                         
                                     };
            tiposConta.ForEach(i => i.DataCadastro = DateTime.Now);
            tiposConta.ForEach(i => context.TiposConta.Add(i));
            context.SaveChanges();

            var contas = new List<Conta>
                                     {
                                         new Conta {Nome = "Corrente-1", TipoConta = tiposConta[0]}
                                     };
            contas.ForEach(i => i.DataCadastro = DateTime.Now);
            contas.ForEach(i => context.Contas.Add(i));
            context.SaveChanges();

        }
    }
}
