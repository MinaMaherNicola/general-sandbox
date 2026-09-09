# PostgreSQL development stack

PostgreSQL `18.6-alpine3.24` and pgAdmin `9.17`, both using Alpine-based images.
The database starts empty, and both services are accessible from this computer only.
The containers are named `postgres` and `pgadmin`.

## Start

The relative file paths and `docker compose` examples below use this directory:

```bash
cd /home/mina/code/general-sandbox/backend/postgresql
```

A local `.env` is provided with the requested development credentials. On a fresh
checkout, create it from the example before starting:

```bash
# Only needed when .env does not exist.
cp .env.example .env
chmod 600 .env
```

Start both services and wait for their health checks:

```bash
docker compose up -d --wait --wait-timeout 300
```

To start the services from any directory, use the absolute Compose path:

```bash
docker compose -f /home/mina/code/general-sandbox/backend/postgresql/compose.yaml up -d --wait --wait-timeout 300
```

## Connect

| Setting | PostgreSQL | pgAdmin web login |
| --- | --- | --- |
| Address | `127.0.0.1:5432` | <http://127.0.0.1:5050> |
| Database | `dev` | — |
| Username | `dev` | `dev@example.com` |
| Password | `12345678` | `12345678` |

The database account `dev` is the PostgreSQL administrator and can create databases,
roles, and tables. pgAdmin uses a separate account with an email address for login.

After logging into pgAdmin, expand **Development → Local PostgreSQL 18** and enter
`12345678` when prompted for the database password. You can choose to save that
password. The connection is already registered with host `postgres`, port `5432`,
database `dev`, and username `dev`. Inside pgAdmin, `postgres` resolves to the database
service on the Compose network; host applications use `127.0.0.1` instead.

Open an SQL console from any directory using the client bundled with PostgreSQL:

```bash
docker exec -it postgres psql -U dev -d dev
```

Try `SELECT version(), current_database(), current_user;` and use `\q` to exit.
This command uses a local Unix socket inside the container, which does not require
a password. Connections from host applications and pgAdmin require the password.

For an application running on this computer, use:

```text
postgresql://dev:12345678@127.0.0.1:5432/dev
```

## Manage the services

```bash
# Show status or follow logs (Ctrl+C exits log viewing).
docker compose ps
docker compose logs -f

# Restart both services.
docker compose restart

# Stop the containers while keeping their data.
docker compose stop

# Remove containers and the network while keeping both named volumes.
docker compose down

# Recreate containers with the retained data.
docker compose up -d --wait --wait-timeout 300
```

Both services use `unless-stopped`, so Docker restarts them after failures and when
the Docker daemon starts, unless you deliberately stopped them. pgAdmin initially
starts after PostgreSQL passes its readiness check.

## Storage and configuration

Compose creates the named volumes `postgres-dev_postgres_data` and
`postgres-dev_pgadmin_data` for database contents and pgAdmin settings, respectively.
The PostgreSQL volume is mounted at `/var/lib/postgresql`, with version 18 data under
`/var/lib/postgresql/18/docker`. pgAdmin storage is mounted at `/var/lib/pgadmin`.
These volumes survive container recreation and `docker compose down`.

`docker compose down -v` deletes both volumes, including all databases and pgAdmin
settings. Use it only when you intend to reset this stack.

The ignored `.env` contains the local credentials; `.env.example` supplies the
development defaults. PostgreSQL and pgAdmin initialize accounts only with fresh
volumes. Editing `.env` later does not change existing passwords: change them in
PostgreSQL or pgAdmin first, then update `.env` to match.

The read-only `pgadmin/servers.json` definition is imported on pgAdmin's first launch.
If you change `POSTGRES_USER` or `POSTGRES_DB` before that launch, update `Username`
and `MaintenanceDB` in the JSON to match. For an existing pgAdmin volume, edit the
connection through the pgAdmin interface; restarting does not reimport the file.

## Manual backup and restore

The PostgreSQL container includes `psql`, `pg_dump`, and `pg_restore`; no separate
CLI container or host installation is needed. pgAdmin also provides backup and
restore actions in its interface.

Create a custom-format backup of `dev` on the host:

```bash
mkdir -p backups
docker compose exec -T postgres pg_dump -U dev -d dev --format=custom > backups/dev.dump
```

Each run replaces `backups/dev.dump`; choose another filename to keep older backups.
The `backups/` directory is excluded from Git.

Restore that backup into a new database, leaving `dev` available:

```bash
docker compose exec -T postgres createdb -U dev dev_restored
docker compose exec -T postgres pg_restore -U dev -d dev_restored --exit-on-error < backups/dev.dump
docker compose exec postgres psql -U dev -d dev_restored
```

`dev_restored` must not already exist for this example. These commands back up one
database; additional roles and other databases require their own backup strategy.
Backups are manual and are stored on this computer.

## References

- [Official PostgreSQL image and version 18 storage layout](https://hub.docker.com/_/postgres)
- [pgAdmin container configuration](https://www.pgadmin.org/docs/pgadmin4/latest/container_deployment.html)
- [pgAdmin 9.17 Alpine-based Dockerfile](https://github.com/pgadmin-org/pgadmin4/blob/REL-9_17/Dockerfile)
