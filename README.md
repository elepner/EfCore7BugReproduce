# Repo for reproducing bug

This repo reproduces bug introduced in EF Core 7. It also exists in EF Core 8.

## How to run

1. Clone the repo
1. Run `docker-compose up -d`
1. Navigate to `http://localhost:5000/swagger/index.html`
1. Execute any method from SomeController. It tries to migrate the database and read/modify data. It will fail. However if one downgrades to EF Core 6.0.10 and reruns the app, it would work.
