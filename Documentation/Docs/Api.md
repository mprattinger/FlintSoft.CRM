# FlintSoft.CRM

 - [FlintSoft.CRM API](#flintsoftcrm-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

## Auth

### Register

```json
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Michael",
    "lastName": "Prattinger",
    "email": "test@test.com",
    "password": "geheim"
}
```

#### Reqister Response

```json
{
    "id": "9b2445a0-f174-49f5-ba4b-4ee8d48eb3a3",
    "firstName": "firstName",
    "lastName": "lastName",
}
```

### Login

```json
POST {{host}}/auth/login
```

#### Register Request

```json
{
    "email": "test@test.com",
    "password": "geheim"
}
```

#### Reqister Response

```json
{
    "id": "9b2445a0-f174-49f5-ba4b-4ee8d48eb3a3",
    "firstName": "firstName",
    "lastName": "lastName",
    "token": "token"
}
```