using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claustromania.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirRelacionamentosTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario_Func",
                table: "unidade");

            migrationBuilder.DropColumn(
                name: "fk_Pessoa_Id",
                table: "transacao");

            migrationBuilder.DropColumn(
                name: "Capac_Jogadores",
                table: "sala");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "unidade",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Capacidade",
                table: "unidade",
                newName: "capacidade");

            migrationBuilder.RenameColumn(
                name: "Status_uni",
                table: "unidade",
                newName: "ativa");

            migrationBuilder.RenameColumn(
                name: "NomeUnidade",
                table: "unidade",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "transacao",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "transacao",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "fk_Caixa_Id",
                table: "transacao",
                newName: "fk_caixa");

            migrationBuilder.RenameColumn(
                name: "Forma_de_Pagamento",
                table: "transacao",
                newName: "forma_pagamento");

            migrationBuilder.RenameColumn(
                name: "Data_da_Transacao",
                table: "transacao",
                newName: "data_transacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sala",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status_Sala",
                table: "sala",
                newName: "ativa");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "sala",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Turno",
                table: "funcionario",
                newName: "turno");

            migrationBuilder.RenameColumn(
                name: "Salario",
                table: "funcionario",
                newName: "salario");

            migrationBuilder.RenameColumn(
                name: "Data_Contratacao",
                table: "funcionario",
                newName: "data_contratacao");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "funcionario",
                newName: "cargo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "funcionario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "endereco",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "endereco",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "endereco",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "endereco",
                newName: "complemento");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "endereco",
                newName: "cidade");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "endereco",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "endereco",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "endereco",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "funcionario_nome",
                table: "caixa",
                newName: "nome");

            migrationBuilder.AlterColumn<int>(
                name: "capacidade",
                table: "unidade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "fk_endereco",
                table: "unidade",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "fk_gerente",
                table: "unidade",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "horario_abertura",
                table: "unidade",
                type: "time(6)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "horario_fechamento",
                table: "unidade",
                type: "time(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "fk_pessoa",
                table: "transacao",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "capacidade",
                table: "sala",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "fk_unidade",
                table: "sala",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "pessoa",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "pessoa",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Nascimento",
                table: "pessoa",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "pessoa",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco",
                table: "jogo",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "dificuldade",
                table: "jogo",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "salario",
                table: "funcionario",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_contratacao",
                table: "funcionario",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "fk_pessoa",
                table: "funcionario",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "endereco",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "endereco",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "total_transacoes",
                table: "caixa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "caixa",
                keyColumn: "observacoes",
                keyValue: null,
                column: "observacoes",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "observacoes",
                table: "caixa",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "fk_funcionario",
                table: "caixa",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "fk_unidade",
                table: "caixa",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    nivel_experiencia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fk_pessoa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cliente", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gerente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fk_funcionario = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gerente", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reserva",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    data_reserva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    fk_cliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reserva", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sala_jogo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    fk_sala = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    fk_jogo = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sala_jogo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_transacao_fk_caixa",
                table: "transacao",
                column: "fk_caixa");

            migrationBuilder.CreateIndex(
                name: "ix_transacao_fk_pessoa",
                table: "transacao",
                column: "fk_pessoa");

            migrationBuilder.AddForeignKey(
                name: "fk_transacao_caixa_fk_caixa",
                table: "transacao",
                column: "fk_caixa",
                principalTable: "caixa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transacao_pessoa_fk_pessoa",
                table: "transacao",
                column: "fk_pessoa",
                principalTable: "pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_transacao_caixa_fk_caixa",
                table: "transacao");

            migrationBuilder.DropForeignKey(
                name: "fk_transacao_pessoa_fk_pessoa",
                table: "transacao");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "gerente");

            migrationBuilder.DropTable(
                name: "reserva");

            migrationBuilder.DropTable(
                name: "sala_jogo");

            migrationBuilder.DropIndex(
                name: "ix_transacao_fk_caixa",
                table: "transacao");

            migrationBuilder.DropIndex(
                name: "ix_transacao_fk_pessoa",
                table: "transacao");

            migrationBuilder.DropColumn(
                name: "fk_endereco",
                table: "unidade");

            migrationBuilder.DropColumn(
                name: "fk_gerente",
                table: "unidade");

            migrationBuilder.DropColumn(
                name: "horario_abertura",
                table: "unidade");

            migrationBuilder.DropColumn(
                name: "horario_fechamento",
                table: "unidade");

            migrationBuilder.DropColumn(
                name: "fk_pessoa",
                table: "transacao");

            migrationBuilder.DropColumn(
                name: "capacidade",
                table: "sala");

            migrationBuilder.DropColumn(
                name: "fk_unidade",
                table: "sala");

            migrationBuilder.DropColumn(
                name: "fk_pessoa",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "fk_funcionario",
                table: "caixa");

            migrationBuilder.DropColumn(
                name: "fk_unidade",
                table: "caixa");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "unidade",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "capacidade",
                table: "unidade",
                newName: "Capacidade");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "unidade",
                newName: "NomeUnidade");

            migrationBuilder.RenameColumn(
                name: "ativa",
                table: "unidade",
                newName: "Status_uni");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "transacao",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "transacao",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "forma_pagamento",
                table: "transacao",
                newName: "Forma_de_Pagamento");

            migrationBuilder.RenameColumn(
                name: "fk_caixa",
                table: "transacao",
                newName: "fk_Caixa_Id");

            migrationBuilder.RenameColumn(
                name: "data_transacao",
                table: "transacao",
                newName: "Data_da_Transacao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "sala",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "sala",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "ativa",
                table: "sala",
                newName: "Status_Sala");

            migrationBuilder.RenameColumn(
                name: "turno",
                table: "funcionario",
                newName: "Turno");

            migrationBuilder.RenameColumn(
                name: "salario",
                table: "funcionario",
                newName: "Salario");

            migrationBuilder.RenameColumn(
                name: "data_contratacao",
                table: "funcionario",
                newName: "Data_Contratacao");

            migrationBuilder.RenameColumn(
                name: "cargo",
                table: "funcionario",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "funcionario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "endereco",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "endereco",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "endereco",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "endereco",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "endereco",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "endereco",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "endereco",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "endereco",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "caixa",
                newName: "funcionario_nome");

            migrationBuilder.AlterColumn<int>(
                name: "Capacidade",
                table: "unidade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horario_Func",
                table: "unidade",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "fk_Pessoa_Id",
                table: "transacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capac_Jogadores",
                table: "sala",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "pessoa",
                keyColumn: "Sexo",
                keyValue: null,
                column: "Sexo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "pessoa",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "pessoa",
                keyColumn: "Nome",
                keyValue: null,
                column: "Nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "pessoa",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Nascimento",
                table: "pessoa",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "pessoa",
                keyColumn: "CPF",
                keyValue: null,
                column: "CPF",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "pessoa",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "preco",
                table: "jogo",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "jogo",
                keyColumn: "dificuldade",
                keyValue: null,
                column: "dificuldade",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "dificuldade",
                table: "jogo",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Salario",
                table: "funcionario",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "funcionario",
                keyColumn: "Data_Contratacao",
                keyValue: null,
                column: "Data_Contratacao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Data_Contratacao",
                table: "funcionario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "endereco",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "endereco",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_transacoes",
                table: "caixa",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "observacoes",
                table: "caixa",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
