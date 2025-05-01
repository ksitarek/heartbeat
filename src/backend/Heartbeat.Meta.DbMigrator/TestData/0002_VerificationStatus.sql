INSERT INTO "verification_status" ("id", "app_id", "created_at", "verification_token",
                                   "verification_strategy", "was_verification_successful",
                                   "last_verification_date_time")
VALUES ('a2e4c6a0-780f-4e85-8f07-091f78f4d3ba', 'c1a1f750-dc71-4b4d-914d-afe308f640e5', '2025-04-03T08:00:00Z',
        'V1.2.0B6A45C5D67244F4BB76BE2E11929E53', 'DnsRecord', TRUE, '2025-04-04T10:00:00Z')
ON CONFLICT ("id")
    DO UPDATE SET "app_id"                      = EXCLUDED."app_id",
                  "created_at"                  = EXCLUDED."created_at",
                  "verification_token"          = EXCLUDED."verification_token",
                  "verification_strategy"       = EXCLUDED."verification_strategy",
                  "was_verification_successful" = EXCLUDED."was_verification_successful",
                  "last_verification_date_time" = EXCLUDED."last_verification_date_time";
