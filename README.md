# ETrade

A distributed e-commerce backend platform built with ASP.NET Core Microservices Architecture.

## Overview

ETrade is a backend-focused e-commerce platform designed using modern software architecture principles and distributed system patterns.

The primary objective of the project is to simulate a real-world e-commerce ecosystem where business domains are separated into independent microservices. Instead of placing all functionality inside a single monolithic application, responsibilities are divided across multiple services such as Catalog, Basket, Order, Cargo, Discount, and Identity.

Each service manages its own business logic and data storage strategy while communication with clients is handled through a centralized Ocelot API Gateway.

The project demonstrates enterprise-level backend development concepts including:

* Microservices Architecture
* API Gateway Pattern
* JWT Authentication & Authorization
* CQRS Pattern
* Clean Architecture
* Repository Pattern
* Redis Caching
* MongoDB Integration
* SQL Server Integration
* Dapper
* Entity Framework Core
* Distributed Service Design
* Polyglot Persistence

---

## Why Microservices?

Traditional monolithic applications place all business logic inside a single deployable application. As the application grows, maintenance becomes more difficult and scaling specific parts of the system becomes challenging.

ETrade addresses these challenges by separating responsibilities into dedicated services.

Benefits of this approach include:

* Independent development of services
* Easier maintenance
* Better scalability
* Clear separation of concerns
* Technology flexibility
* Improved fault isolation

---

## System Architecture

```text
                                ┌─────────────────┐
                                │     Clients     │
                                └────────┬────────┘
                                         │
                                         ▼
                        ┌─────────────────────────────────┐
                        │      Ocelot API Gateway         │
                        │      localhost:5000            │
                        └──────────────┬──────────────────┘
                                       │
     ┌──────────────┬──────────────────┼─────────────────┬──────────────┬──────────────┐
     ▼              ▼                  ▼                 ▼              ▼
┌──────────┐   ┌──────────┐      ┌──────────┐      ┌──────────┐   ┌──────────┐
│ Catalog  │   │ Basket   │      │ Order    │      │ Cargo    │   │ Discount │
│ Service  │   │ Service  │      │ Service  │      │ Service  │   │ Service  │
└──────────┘   └──────────┘      └──────────┘      └──────────┘   └──────────┘
       │              │                 │                 │               │
       ▼              ▼                 ▼                 ▼               ▼
   MongoDB         Redis           SQL Server       SQL Server      SQL Server

                                       │
                                       ▼

                              ┌────────────────┐
                              │ Identity       │
                              │ Service        │
                              └────────────────┘
```

All client requests enter the system through the API Gateway, which forwards requests to the appropriate microservice.

---

## Services

### Identity Service

The Identity Service is responsible for authentication and authorization.

Responsibilities:

* User registration
* User login
* JWT token generation
* User identity management
* Access control

Port:

```text
http://localhost:5001
```

Authentication Flow:

1. User logs in.
2. Identity Service validates credentials.
3. JWT token is generated.
4. Client includes token in subsequent requests.
5. Protected services validate the token before processing requests.

---

### Catalog Service

The Catalog Service manages all product-related content displayed to customers.

Responsibilities:

* Product management
* Product details
* Product images
* Categories
* Feature sliders
* About section content
* Contact information

Port:

```text
http://localhost:5202
```

Database:

```text
MongoDB
```

MongoDB was selected because product information is naturally document-oriented and benefits from flexible schema design.

---

### Basket Service

The Basket Service manages customer shopping carts.

Responsibilities:

* Create baskets
* Add products to baskets
* Remove products from baskets
* Update basket quantities
* Store active shopping sessions

Port:

```text
http://localhost:5194
```

Database:

```text
Redis
```

Redis provides extremely fast access times, making it suitable for temporary and frequently changing shopping cart data.

---

### Order Service

The Order Service manages order creation and processing.

Responsibilities:

* Create orders
* Store order details
* Manage shipping addresses
* Handle order workflows

Port:

```text
http://localhost:5154
```

Database:

```text
SQL Server
```

Architectural Patterns:

* CQRS
* Repository Pattern
* Clean Architecture

The service separates commands and queries to improve maintainability and scalability.

---

### Cargo Service

The Cargo Service manages shipment and delivery operations.

Responsibilities:

* Cargo company management
* Cargo customer management
* Cargo tracking
* Delivery operations
* Shipment information

Port:

```text
http://localhost:5164
```

Database:

```text
SQL Server
```

Modules:

* Cargo Company
* Cargo Customer
* Cargo Detail
* Cargo Operation

---

### Discount Service

The Discount Service manages discount and coupon operations.

Responsibilities:

* Create coupons
* Update coupons
* Delete coupons
* Validate coupons
* Manage discount campaigns

Port:

```text
http://localhost:5152
```

Database:

```text
SQL Server
```

Data Access Technology:

```text
Dapper
```

Dapper is used to provide lightweight and high-performance data access.

---

## API Gateway

The platform uses Ocelot API Gateway as the central routing layer.

Gateway Address:

```text
http://localhost:5000
```

The gateway acts as a single entry point for all client applications.

Advantages:

* Centralized routing
* Service abstraction
* Simplified client communication
* Improved maintainability
* Easier scalability

### Configured Routes

| Route                | Destination      |
| -------------------- | ---------------- |
| /services/catalog/*  | Catalog Service  |
| /services/basket/*   | Basket Service   |
| /services/order/*    | Order Service    |
| /services/cargo/*    | Cargo Service    |
| /services/discount/* | Discount Service |

Example:

```http
GET http://localhost:5000/services/catalog/Product
```

The API Gateway forwards the request to the Catalog Service automatically.

---

## Database Strategy

ETrade follows a Polyglot Persistence approach.

Different services use different database technologies depending on their requirements.

| Service          | Database   |
| ---------------- | ---------- |
| Catalog Service  | MongoDB    |
| Basket Service   | Redis      |
| Order Service    | SQL Server |
| Cargo Service    | SQL Server |
| Discount Service | SQL Server |

This allows each service to use the most appropriate storage technology for its workload.

---

## Technologies

### Backend

* ASP.NET Core
* .NET
* RESTful APIs
* Swagger/OpenAPI

### Databases

* SQL Server
* MongoDB
* Redis

### Authentication

* JWT Authentication
* ASP.NET Identity

### Data Access

* Entity Framework Core
* Dapper

### Architecture

* Microservices Architecture
* CQRS
* Repository Pattern
* Clean Architecture
* Dependency Injection
* API Gateway Pattern

---

## Security

Authentication and authorization are implemented using JWT Bearer Tokens.

Protected endpoints require valid access tokens generated by the Identity Service.

Security Features:

* User Authentication
* User Authorization
* Token Validation
* Protected API Endpoints

---

## Running Locally

### Prerequisites

* .NET SDK
* SQL Server
* MongoDB
* Redis
* Visual Studio 2022

### Installation

Clone the repository:

```bash
git clone https://github.com/yourusername/ETrade.git
```

### Start Infrastructure

Before running the application, make sure the following services are available:

* SQL Server
* MongoDB
* Redis

### Start Services

Run services in the following order:

1. Identity Service
2. Catalog Service
3. Basket Service
4. Discount Service
5. Order Service
6. Cargo Service
7. API Gateway

### Access Gateway

```text
http://localhost:5000
```

---

## Current Status

Implemented:

* Microservice Architecture
* Ocelot API Gateway
* JWT Authentication
* Catalog Service
* Basket Service
* Discount Service
* Cargo Service
* Order Service Foundation
* MongoDB Integration
* Redis Integration
* SQL Server Integration
* CQRS Implementation
* Swagger Documentation

Planned Improvements:

* Docker Support
* Container Orchestration
* Centralized Logging
* Monitoring and Observability
* CI/CD Pipeline
* Cloud Deployment

---

## Purpose

ETrade was developed to explore modern backend development practices and enterprise application architecture using ASP.NET Core and Microservices Architecture.

The project focuses on scalability, maintainability, and separation of concerns while demonstrating technologies and patterns commonly used in production-grade distributed systems.
