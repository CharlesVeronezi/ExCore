\c autentica;

CREATE TABLE IF NOT EXISTS public.conexao_cliente_cloud (
    id INT PRIMARY KEY,
    idempresa INT,
    database VARCHAR(155),
    host VARCHAR(50),
    port INT,
    password VARCHAR(155),
    "user" VARCHAR(155),
    ultima_edicao_por VARCHAR(155),
    st_isat BOOLEAN,
    data_criacao DATE,
    data_atualizacao DATE,
    st_contingencia BOOLEAN,
    ds_host_contingencia VARCHAR(15)
);

CREATE TABLE IF NOT EXISTS public.autentica_user (
    iduser NUMERIC(10) PRIMARY KEY,
    idempresa NUMERIC(10),
    usuario VARCHAR(30),
    chave VARCHAR(35),
    empresa TEXT,
    bloqueia CHAR(1),
    sr_recno NUMERIC(15),
    bloq_portal_cli BOOLEAN,
    email TEXT
);

INSERT INTO public.conexao_cliente_cloud (id, idempresa, database, host, port, password, "user", st_isat, data_criacao, st_contingencia) 
VALUES 
(1, 100, 'nsa', 'banco_server', 5432, 'postgres', 'postgres', true, NOW(), false),
(2, 101, 'salmeron', 'banco_server', 5432, 'postgres', 'postgres', true, NOW(), false)
ON CONFLICT DO NOTHING;

INSERT INTO public.autentica_user (iduser, idempresa, usuario, chave, empresa, bloqueia, bloq_portal_cli, email)
VALUES 
(1, 100, 'AdminNSA', 'e10adc3949ba59abbe56e057f20f883e', 'Empresa NSA', 'N', false, 'admin@nsa.com.br'),
(2, 101, 'AdminSalmeron', 'e10adc3949ba59abbe56e057f20f883e', 'Empresa Salmeron', 'N', false, 'admin@salmeron.com.br'),
(3, 100, 'DevUser', 'e10adc3949ba59abbe56e057f20f883e', 'Empresa NSA', 'N', false, 'dev@nsa.com.br')
ON CONFLICT DO NOTHING;