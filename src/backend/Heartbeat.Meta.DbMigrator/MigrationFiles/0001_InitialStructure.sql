CREATE TYPE "verification_strategy" AS ENUM(
    'FileUpload',
    'HttpHeader',
    'DnsRecord'
    );

CREATE TYPE "availability_status" AS ENUM (
    'Up',
    'Down',
    'Unknown'
    );

CREATE TABLE "app"
(
    "id"    UUID PRIMARY KEY,
    "label" TEXT NOT NULL
);

CREATE TABLE "verification_status"
(
    "id"                          UUID PRIMARY KEY,
    "app_id"                      UUID                    NOT NULL,
    "created_at"                  TIMESTAMPTZ             NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "verification_token"          TEXT,
    "verification_strategy"       "verification_strategy" NOT NULL,
    "was_verification_successful" BOOLEAN                 NOT NULL,
    CONSTRAINT "fk_verification_status_app" FOREIGN KEY ("app_id") REFERENCES "app" ("id") ON DELETE CASCADE
);

CREATE TABLE "check"
(
    "id"                UUID PRIMARY KEY,
    "app_id"            UUID     NOT NULL,
    "label"             TEXT     NOT NULL,
    "interval"          INTERVAL NOT NULL,
    "timeout"           INTERVAL NOT NULL,
    "retries"           INTEGER  NOT NULL,
    "url"               TEXT     NOT NULL,
    "port"              INTEGER  NOT NULL,
    "expected_response" TEXT,
    "collect_response"  BOOLEAN  NOT NULL,
    CONSTRAINT "fk_check_app" FOREIGN KEY ("app_id") REFERENCES "app" ("id") ON DELETE CASCADE
);

CREATE TABLE "check_response"
(
    "id"                 UUID PRIMARY KEY,
    "response_collected" BOOLEAN NOT NULL,
    "response"           TEXT
);

CREATE TABLE "check_status_log"
(
    "id"                UUID PRIMARY KEY,
    "check_id"          UUID                  NOT NULL,
    "status"            "availability_status" NOT NULL,
    "created_at"        TIMESTAMPTZ           NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "check_response_id" UUID,
    CONSTRAINT "fk_check_status_log_check" FOREIGN KEY ("check_id") REFERENCES "check" ("id") ON DELETE CASCADE,
    CONSTRAINT "fk_check_status_log_response" FOREIGN KEY ("check_response_id") REFERENCES "check_response" ("id")
);