# MySQL and Sakila for Learning SQL

MySQL `26.7.0` with the official Sakila schema and sample data.

## Connect

| Setting | Value |
| --- | --- |
| Host | `127.0.0.1` |
| Port | `3306` |
| Database | `sakila` |
| User | `dev` |
| Password | `12345678` |

The `dev` user has full permissions on `sakila`, including creating tables and changing data for exercises. Connections are available from this computer only.

Open the SQL console using the client already inside the container:

```bash
cd /home/mina/mysql-sakila
docker compose exec mysql mysql -u dev -p sakila
```

Enter `12345678` at the password prompt. Try:

```sql
SHOW FULL TABLES;
SELECT COUNT(*) FROM film;
SELECT first_name, last_name FROM actor LIMIT 5;
```

The original `film` table has 1,000 rows. Use `exit` to leave the console.

## Manage the container

Run these commands from `/home/mina/mysql-sakila`:

```bash
# Start and wait until MySQL is ready.
docker compose up -d --wait --wait-timeout 300

# Show status or follow the logs (Ctrl+C exits log viewing).
docker compose ps
docker compose logs -f mysql

# Restart while retaining the database.
docker compose restart mysql

# Stop MySQL while retaining the container and database.
docker compose stop mysql

# Remove the container and network, retaining the database volume.
docker compose down

# Recreate the container with the retained database.
docker compose up -d --wait --wait-timeout 300
```

The restart policy is `unless-stopped`: MySQL recovers after failures and starts with Docker after a reboot, unless you deliberately stopped it. Docker is enabled to start at boot on this computer.

## Storage and initialization

The named Docker volume `sakila_mysql_data` is mounted at `/var/lib/mysql`. It stores the database, users, and your exercise changes independently of the container. An ordinary restart, reboot, or `docker compose down` followed by `up` preserves this data.

**Do not use `docker compose down -v` or delete `sakila_mysql_data` if you want to keep your work.** A volume survives container replacement but is not a backup against disk failure.

The `init/` directory is mounted read-only at `/docker-entrypoint-initdb.d`. On the first startup with an empty data volume, MySQL imports `01-sakila-schema.sql`, then `02-sakila-data.sql`. These scripts do not run again when the volume already contains a database. The schema script drops and recreates `sakila`; manually rerunning it would erase your exercise changes.

The SQL files are unmodified files from the [official Sakila archive](https://downloads.mysql.com/docs/sakila-db.tar.gz), retrieved on September 7, 2026. See the [Sakila installation guide](https://dev.mysql.com/doc/sakila/en/sakila-installation.html) and [official MySQL image documentation](https://hub.docker.com/_/mysql).

## Credentials

The local `.env` file contains the development credentials and a separate generated root password. It is readable only by your user and excluded from Git. Root access is limited to connections inside the container.

Changing `.env` after initialization does not change existing database users or passwords; those must be changed with SQL first, then reflected in `.env`.
