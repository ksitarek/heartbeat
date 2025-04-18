
INSERT INTO "verification_status" ("id", "app_id", "created_at", "verification_token",
                                   "verification_strategy", "was_verification_successful")
VALUES ('a2e4c6a0-780f-4e85-8f07-091f78f4d3ba', 'c1a1f750-dc71-4b4d-914d-afe308f640e5', '2025-04-03T08:00:00Z',
        '3B88EF30-A2A9-4768-93A7-75926F55BF3B', 'DnsRecord', TRUE) ON CONFLICT ("id") DO NOTHING;
